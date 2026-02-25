# SaaS.NET

**SaaS.NET** is a **modular, Clean Architecture starter kit** for building multi-tenant SaaS applications in **.NET 10 / ASP.NET Core**.

It provides a fully functional backend with authentication, role-based access control, multi-tenancy, vertical slice features, and a clean project structure — ready to fork, run, and extend for your own SaaS projects.

---

## Features

- **Clean Architecture**: Core → Application → Infrastructure → Web → Shared
- **Multi-Tenancy**: Tenant resolver, middleware, scoped DbContexts
- **Authentication & Authorization**: JWT-based login, role-based access control
- **Vertical Slices**: Features organized by domain (Tenants, Auth, Billing)
- **EF Core Persistence**: AppDbContext + TenantDbContext
- **Dependency Injection**: Modular service registration
- **Unit & Integration Tests**: xUnit test setup for Core, Application, Infrastructure

---

## Project Structure

```text
saas-dotnet/
├── src/
│   ├── SaaS.NET.Core/          # Domain layer: Entities, Interfaces, Policies
│   ├── SaaS.NET.Contracts/     # Shared API surface: DTOs & Integration Events
│   ├── SaaS.NET.Application/   # Business logic & vertical slices
│   ├── SaaS.NET.Infrastructure/# Adapters: EF Core, Identity, Multi-Tenancy
│   ├── SaaS.NET.Web/           # Entry point: Controllers & DI setup
│   ├── SaaS.NET.Migrations/    # Migration & database seeding runner
│   └── SaaS.NET.Shared/        # Utilities & extensions
├── tests/                      # Unit, Integration, and Architecture tests
├── docker/                     # Docker configuration
└── saas-dotnet.sln             # Solution file
```

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/devsarfo/saas-dotnet.git
cd saas-dotnet
```

### 2. Configure Environment

- Update `appsettings.json` or environment variables:
    - Database connection string
    - JWT / Identity options
    - Email / SMTP config
    - Tenant defaults

### 3. Run Migrations

```bash
dotnet ef database update --project src/SaaS.NET.Infrastructure
```

- Seeds initial tenants, users, and roles.

### 4. Run the Web API

```bash
dotnet run --project src/SaaS.NET.Web
```

- API available at `https://localhost:7108` (default).

---

## Adding New Features

- Follow **Clean Architecture** principles:
    - Add new **Entities / ValueObjects** in `Core`
    - Add new **Application Services** or vertical slices in `Application/Features`
    - Add **DB configurations / repositories** in `Infrastructure/Persistence`
    - Add thin **API endpoints** in `Web/Controllers`

---

## Updating from Upstream

1. Add upstream repository:

```bash
git remote add upstream https://github.com/devsarfo/saas-dotnet.git
```

2. Fetch latest updates:

```bash
git fetch upstream
```

3. Merge changes:

```bash
git merge upstream/main
# or rebase if preferred:
git rebase upstream/main
```

4. Run migrations if required:

```bash
dotnet ef database update --project src/SaaS.NET.Infrastructure
```

---

## Testing

- **Unit Tests:** `tests/SaaS.NET.UnitTests`
- **Integration Tests:** `tests/SaaS.NET.IntegrationTests`
- **Architecture Tests:** `tests/SaaS.NET.ArchitectureTests`

```bash
dotnet test
```

---

## Roadmap

- Add **Specific modules** (Billing, ABAC, Audit Logs)
- Add **Queues / Background Jobs** support
- Add **Admin Dashboard (Angular / React)**

---

## Contributing

Contributions are welcome! Please fork the repo and submit pull requests.  
Follow the **Clean Architecture principles** and add unit/integration tests for new features.

