# eShopLite Microservices Architecture

This solution demonstrates the conversion of a Blazor monolith application into a microservices architecture.

## Architecture Overview

### Applications

1. **eShopLite.Store** (Port: Default/5000-5001)
   - Main Blazor Server application
   - Contains the UI components and pages
   - Communicates with microservices via HTTP API clients
   - No direct database access

2. **eShopLite.Products** (Port: 7001)
   - Products microservice with minimal API
   - Manages product data using SQLite database (`products.db`)
   - Endpoints:
     - `GET /api/products` - Get all products
     - `GET /api/products/{id}` - Get product by ID

3. **eShopLite.StoreInfo** (Port: 7002)
   - Store information microservice with minimal API
   - Manages store location data using SQLite database (`storeinfo.db`)
   - Endpoints:
     - `GET /api/stores` - Get all stores
     - `GET /api/stores/{id}` - Get store by ID

### Database Separation

- **ProductDbContext**: Contains only Product entity and related configuration
- **StoreInfoDbContext**: Contains only Store entity and related configuration
- Each microservice maintains its own SQLite database with seeded data

### API Communication

- **ProductApiClient**: HTTP client for communicating with Products API
- **StoreInfoApiClient**: HTTP client for communicating with StoreInfo API
- Both inherit from base **ApiClient** class for common HTTP functionality

## Running the Application

1. Start the Products API:
   ```bash
   cd src/eShopLite.Products
   dotnet run
   ```

2. Start the StoreInfo API:
   ```bash
   cd src/eShopLite.StoreInfo
   dotnet run
   ```

3. Start the main Store application:
   ```bash
   cd src/eShopLite.Store
   dotnet run
   ```

## Configuration

The Store application is configured to connect to the microservices via:
- Products API: `https://localhost:7001`
- StoreInfo API: `https://localhost:7002`

These URLs can be configured in `appsettings.Development.json`.

## API Documentation

Both microservices expose OpenAPI documentation:
- Products API: `https://localhost:7001/openapi`
- StoreInfo API: `https://localhost:7002/openapi`