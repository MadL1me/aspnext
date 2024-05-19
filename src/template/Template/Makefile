# Makefile
//#if (UseReactVite)
FRONTEND_DIR = react-vite
//#endif
//#if (UseNext)
FRONTEND_DIR = react-next
//#endif
//#if (UsePostgreSql)
DB_TASK = run_db
//#endif

HOME := $(shell echo $$HOME)
PASSWORD := YOUR_PASSWORD # Replace with actual password

.PHONY: init init_frontend init_backend init_db init_certs run_backend $(DB_TASK) run_frontend run

init: init_frontend init_backend init_certs init_db

//#if (UseAnySpa)
init_frontend:
	@echo "Initialize the front-end project"
	cd $(FRONTEND_DIR) && yarn install
//#endif

init_backend:
	@echo "Initialize the back-end project"
	cd AspnextTemplate && dotnet restore && docker compose build

//#if (UsePostgreSql)
init_db:
	@echo "Initialize the database"
	cd infra/postgres-docker-compose.yaml && docker compose up -d
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
	cd AspnextTemplate/DB && docker compose up --no-recreate -d
//#endif

//#if (UseAnySpa)
run_frontend:
	@echo "Run the frontend"
	cd $(FRONTEND_DIR) && yarn dev
//#endif

//#if (UseAnySpa)
run: run_backend run_frontend
	@echo "Run the project"
//#else
run: run_backend
	@echo "Run the project"
//#endif