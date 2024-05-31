# Makefile
//#if (UsePostgreSql)
DB_TASK = run_db
//#endif
HOME := $(shell echo $$HOME)
PASSWORD := YOUR_PASSWORD # Replace with actual password

.PHONY: init init_frontend init_backend init_db init_certs run_backend $(DB_TASK) run_frontend run_auth run \
		run_tracing run_metrics run_grafana

init: init_frontend init_backend init_certs init_db

init_backend:
	@echo "Initialize the back-end project"
	cd AspnextTemplate && dotnet restore && docker compose build

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
	docker compose --file infra/docker-compose-postgres.yaml up -d
//#endif

//#if (AddZitadelAuth)
run_auth:
	@echo "Run Zitadel identity provider"
	docker compose --file infra/docker-compose-zitadel.yaml up -d
//#endif

//#if (AddObservability)
run_tracing:
	docker compose --file infra/docker-compose-jaeger.yaml up -d

run_metrics:
	docker compose --file infra/docker-compose-prometheus.yaml up -d

run_grafana:
	docker compose --file infra/docker-compose-grafana.yaml up -d
//#endif

run: run_backend
	@echo "Run the project"
