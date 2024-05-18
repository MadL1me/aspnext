# Define environment variables
TEMPL_DIR := src/template
DOTENV := .env.prod
include $(DOTENV)

.PHONY: remove create create_release install new run-dotnet run all list info deploy

clean:
	cd experiments && \
	rm -rf *

install-2:
	dotnet new install ./

uninstall:
	dotnet new uninstall ./

remove:
	cd $(TEMPL_DIR)/nupkg && \
	pwd && \
	dotnet new --uninstall $$TEMPL_NAME && \
	rm -rf *

create:
	cd $(TEMPL_DIR) && \
	dotnet pack

create_release:
	cd $(TEMPL_DIR) && \
	dotnet pack --configuration Release

install:
	cd $(TEMPL_DIR)/nupkg && \
	dotnet new --install $$NUGET_FILE

new:
	cd $(TEMPL_DIR)/nupkg && \
	dotnet new $$TEMPL_DOTNET_NAME -o $$TEST_PROJ_NAME

run-dotnet:
	cd $(TEMPL_DIR)/nupkg/$(TEST_PROJ_NAME) && \
	dotnet run

run:
	cd $(TEMPL_DIR)/nupkg/$(TEST_PROJ_NAME)/$(TEST_PROJ_NAME) && \
	docker compose up

all: remove create install new

list:
	dotnet new -l

info:
	dotnet new $$TEMPL_DOTNET_NAME -h

deploy: remove
	cd $(TEMPL_DIR)/nupkg && \
	make create_release && \
	dotnet nuget push $$NUGET_FILE --api-key $$NUGET_APIKEY --source https://api.nuget.org/v3/index.json
