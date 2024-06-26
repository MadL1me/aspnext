# Define environment variables
TEMPL_DIR := src/template
DOTENV := .env.prod
TEST_PROJ_OUT := "experiments/Rule"
include $(DOTENV)
export $(shell sed 's/=.*//' $(DOTENV))

.PHONY: remove create create_release install new run-dotnet run all list info deploy

all: uninstall clean remove pack install new

clean:
	cd experiments && \
	rm -rf *

install:
	dotnet new install ./

uninstall:
	dotnet new uninstall ./

remove:
	cd $(TEMPL_DIR)/nupkg && \
	pwd && \
	dotnet new --uninstall $$TEMPL_NAME && \
	rm -rf *

pack:
	cd $(TEMPL_DIR) && \
	dotnet pack

pack-release:
	cd $(TEMPL_DIR) && \
	dotnet pack --configuration Release

new:
	rm -rf $(TEST_PROJ_OUT)
	dotnet new $(TEMPL_DOTNET_NAME) -o $(TEST_PROJ_OUT)

run-dotnet:
	cd $(TEST_PROJ_OUT) && \
	dotnet run

info:
	dotnet new $$TEMPL_DOTNET_NAME -h

deploy: remove pack-release
	cd $(TEMPL_DIR)/nupkg && \
	dotnet nuget push $(NUGET_FILE) --api-key $(NUGET_API_KEY) --source https://api.nuget.org/v3/index.json
