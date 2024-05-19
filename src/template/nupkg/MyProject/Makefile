# Makefile
FRONTEND_DIR = react-next
DB_TASK = run_db

HOME := $(shell echo $$HOME)
PASSWORD := YOUR_PASSWORD # Replace with actual password

.PHONY: init init_frontend init_backend init_db init_certs run_backend $(DB_TASK) run_frontend run

init: init_frontend init_backend init_certs init_db

init_frontend:
	@echo "Initialize the front-end project"
	cd $(FRONTEND_DIR) && yarn install

init_backend:
	@echo "Initialize the back-end project"
	cd MyProject && dotnet restore && docker compose build

init_db:
	@echo "Initialize the database"
	cd infra/postgres-docker-compose.yaml && docker compose up -d

init_certs:
	@echo "Generate self-signed certificates"
	dotnet dev-certs https -ep $(HOME)/.aspnet/https/MyProject.pfx -p $(PASSWORD)
	dotnet dev-certs https --trust
	# openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365 -nodes -subj "/CN=localhost"

run_backend: $(DB_TASK)
	@echo "Run the backend"
	cd MyProject && docker compose up --build

run_db:
	@echo "Run the database"
	cd MyProject/DB && docker compose up --no-recreate -d

run_frontend:
	@echo "Run the frontend"
	cd $(FRONTEND_DIR) && yarn dev

run: run_backend run_frontend
	@echo "Run the project"