# Makefile
//#if (UsePostgreSql)
DB_TASK = run_db
//#endif
HOME := $(shell echo $$HOME)
PASSWORD := YOUR_PASSWORD # Replace with actual password

.PHONY: init init_frontend init_backend init_db init_certs run_backend $(DB_TASK) run_frontend run_auth run

init: init_frontend init_backend init_certs init_db

init_backend:
	@echo "Initialize the back-end project"
	cd AspnextTemplate && dotnet restore && docker compose build

//#if (UsePostgreSql)
init_db:
	@echo "Initialize the database"
	cd infra && docker compose --file docker-compose-postgres.yaml up -d
//#endif

init_certs:
	@echo "Generate self-signed certificates"
	dotnet dev-certs https -ep $(HOME)/.aspnet/https/AspnextTemplate.pfx -p $(PASSWORD)
	dotnet dev-certs https --trust
	# openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365 -nodes -subj "/CN=localhost"

run_backend: $(DB_TASK)
	@echo "Run the backend"
	cd AspnextTemplate && docker compose up --build

//#if (UsePostgreSql)
run_db:
	@echo "Run the database"
	cd infra && docker compose --file docker-compose-postgres.yaml up -d
//#endif

//#if (AddZitadelAuth)
run_auth:
	@echo "Run Zitadel identity provider"
	cd infra && docker compose --file docker-compose-zitadel.yaml up -d
//#endif

run: run_backend
	@echo "Run the project"
