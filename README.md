# 🌱 Croppilot Backend

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/Smart-Farming-Graduation-Project/Back-End)
[![API Documentation](https://img.shields.io/badge/API-Swagger-green.svg)](https://localhost:7000/swagger)

A comprehensive **Smart Agriculture Management Platform** backend built with .NET 8.0, featuring AI-powered crop management, IoT integration, e-commerce capabilities, and social community features for modern sustainable farming solutions.

## 🎯 Project Overview

Croppilot is an innovative agricultural technology platform designed to revolutionize modern farming through:

- **🤖 AI-Driven Intelligence**: Machine learning models for crop analysis, disease detection, and predictive farming
- **🌐 IoT Integration**: Real-time monitoring of farm equipment, soil conditions, and environmental factors
- **🛒 Agricultural Marketplace**: E-commerce platform for farming products, equipment, and services
- **👥 Farming Community**: Social platform for knowledge sharing, reviews, and agricultural collaboration
- **📊 Smart Analytics**: Comprehensive dashboard with insights, alerts, and data-driven recommendations
- **🚀 Space Technology**: Integration with NASA Mars Rover data for educational and research purposes

### Use Cases

- **🌾 Farm Management**: Monitor crop health, soil conditions, and equipment status in real-time
- **💡 Smart Decisions**: Get AI-powered recommendations for watering, fertilization, and pest control
- **🛍️ Agricultural Commerce**: Buy/sell farming products, rent equipment, and access agricultural services
- **📚 Knowledge Sharing**: Connect with farming communities, share experiences, and learn best practices
- **📈 Business Intelligence**: Analyze farm performance, track yields, and optimize operations

## 🚀 Features

### 🤖 AI-Powered Agriculture

- **Crop Analysis**: Machine learning models for crop health assessment using ONNX runtime
- **Predictive Analytics**: Reinforcement learning models for optimized farming decisions
- **Image Recognition**: MobileNet-based crop disease detection
- **Smart Recommendations**: AI-driven watering and fertilization suggestions

### 🛒 E-Commerce Platform

- **Product Management**: Full CRUD operations for agricultural products
- **Shopping Cart**: Advanced cart functionality with item management
- **Order Processing**: Complete order lifecycle management
- **Payment Integration**: Stripe payment gateway integration
- **Coupon System**: Discount and promotional code management

### 📊 Farm Dashboard & IoT

- **Real-time Monitoring**: Live farm status and equipment tracking
- **Alert System**: Automated notifications for critical farm conditions
- **Weather Integration**: Weather data integration for informed decisions
- **Soil Analysis**: Comprehensive soil health monitoring
- **Equipment Management**: IoT device status and control

### 👥 Social & Community Features

- **User Profiles**: Comprehensive user management system
- **Posts & Comments**: Community interaction platform
- **Reviews & Ratings**: Product and service review system
- **Voting System**: Community-driven content curation
- **Wishlist**: Personal product wishlist functionality

### 🚀 Advanced Integrations

- **NASA Mars Rover Data**: Educational content from space exploration
- **Azure Cosmos DB**: Global data distribution and analytics
- **Notification System**: Real-time push notifications via Twilio
- **Email Services**: MailJet integration for automated communications
- **File Storage**: Azure Blob Storage for media and documents

## 🏗️ Architecture & Project Structure

The project follows **Clean Architecture** principles with clear separation of concerns:

```
📦 Croppilot Backend
├── 🎯 Croppilot.API          # Presentation Layer (Controllers, Middleware, Configuration)
├── 🧠 Croppilot.Core         # Application Layer (CQRS, Business Logic, Features)
├── 📊 Croppilot.Date         # Domain Layer (Entities, DTOs, Models, Identity)
├── 🔧 Croppilot.Services     # External Services Layer (AI, Payments, Communications)
└── 🏗️ Croppilot.Infrastructure # Infrastructure Layer (Database, Repositories, Configurations)
```

### 📁 Detailed Project Structure

#### 🎯 Croppilot.API (Presentation Layer)

```
Croppilot.API/
├── Controllers/           # REST API Controllers (20+ controllers)
│   ├── AIModelController.cs
│   ├── AuthenticationController.cs
│   ├── ProductController.cs
│   └── ...
├── AiModels/             # ONNX Model Files
│   ├── best.onnx         # YOLO v7 Crop Detection
│   ├── mobilenet_model.onnx  # Image Classification
│   └── Rl_Model.onnx     # Reinforcement Learning
├── Bases/                # Base Controller Classes
├── images/               # Uploaded Images Storage
└── Properties/           # Launch Settings & Deployment
```

#### 🧠 Croppilot.Core (Application Layer)

```
Croppilot.Core/
├── Features/             # Feature-based Organization (CQRS)
│   ├── Authentication/   # User Authentication & Management
│   ├── AIModels/        # AI Model Processing
│   ├── Dashboard/       # Farm Analytics & Monitoring
│   ├── Product/         # E-commerce Product Management
│   ├── Carts/           # Shopping Cart Operations
│   ├── Orders/          # Order Processing
│   ├── Posts/           # Social Media Features
│   ├── Reviews/         # Rating & Review System
│   ├── Rovers/          # Mars Rover Data Integration
│   └── ...              # 15+ Feature Modules
├── Mapping/             # Object Mapping Configurations
├── Behaviors/           # Cross-cutting Concerns (Validation, Caching)
└── Attributes/          # Custom Attributes (Caching, etc.)
```

#### 📊 Croppilot.Date (Domain Layer)

```
Croppilot.Date/
├── Models/              # Domain Entities
│   ├── DashboardModels/ # Farm Equipment, Alerts, Soil Data
│   ├── AiModel/         # AI Model Results & Feedback
│   ├── Cart.cs, Product.cs, Order.cs
│   └── ...              # 20+ Domain Models
├── Identity/            # User Identity & Roles
├── DTOs/                # Data Transfer Objects
├── Enum/                # Application Enumerations
└── Helpers/             # Helper Classes & Configurations
```

#### 🔧 Croppilot.Services (External Services)

```
Croppilot.Services/
├── Services/
│   ├── AIServices/      # AI Model Processing Services
│   ├── DashboardServices/ # Farm Monitoring Services
│   ├── EmbeddedServices/ # Cosmos DB, Rover Photo Services
│   ├── AuthenticationService.cs
│   ├── PaymentService.cs
│   └── ...              # 25+ Service Implementations
└── Abstract/            # Service Interfaces
```

#### 🏗️ Croppilot.Infrastructure (Infrastructure Layer)

```
Croppilot.Infrastructure/
├── Data/                # Database Context & Migrations
├── Repositories/        # Data Access Layer
├── Configuration/       # Entity Configurations
├── HealthChecks/        # Application Health Monitoring
├── Seeder/             # Database Seeding
└── Extensions/         # Infrastructure Extensions
```

### Key Patterns

- **CQRS (Command Query Responsibility Segregation)** with MediatR
- **Repository Pattern** for data access abstraction
- **Dependency Injection** for loose coupling
- **FluentValidation** for input validation
- **Mapster** for object mapping
- **Entity Framework Core** with Code First approach

## 🛠️ Technology Stack

### Core Technologies

- **.NET 8.0** - Modern, cross-platform framework
- **ASP.NET Core Web API** - RESTful API development
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Primary database
- **PostgreSQL** - Alternative database support

### AI & Machine Learning

- **Microsoft.ML.OnnxRuntime** - ONNX model inference
- **YOLO v7** - Object detection for crop analysis
- **Azure OpenAI** - Advanced AI capabilities

### Authentication & Security

- **ASP.NET Core Identity** - User management
- **JWT Bearer Tokens** - Stateless authentication
- **Google & Facebook OAuth** - Social authentication
- **Role-based Authorization** - Fine-grained access control

### External Services

- **Azure Blob Storage** - File storage and CDN
- **Stripe** - Payment processing
- **Twilio** - SMS and communication services
- **MailJet** - Email delivery platform
- **Hangfire** - Background job processing

### Monitoring & Health

- **HealthChecks** - Application health monitoring
- **WatchDog.NET** - Request logging and monitoring
- **Hangfire Dashboard** - Background job monitoring

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or [PostgreSQL](https://www.postgresql.org/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/croppilot-backend.git
   cd croppilot-backend
   ```

2. **Restore packages**

   ```bash
   dotnet restore
   ```

3. **Configure connection strings**

   Update `appsettings.Development.json` in `Croppilot.API`:

   ```json
   {
     "ConnectionStrings": {
       "Default": "Server=your-server;Database=CroppilotDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Configure Environment Variables & Settings**

   Create/update `appsettings.json` and `appsettings.Development.json` with the following configurations:

   ```json
   {
     "ConnectionStrings": {
       "Default": "Server=localhost;Database=CroppilotDB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true",
       "Redis": "localhost:6379"
     },
     "JwtSettings": {
       "SecretKey": "your-super-secret-key-here-32-characters-minimum",
       "Issuer": "CroppilotAPI",
       "Audience": "CroppilotUsers",
       "TokenLifetime": "00:30:00",
       "RefreshTokenLifetime": "7.00:00:00"
     },
     "AzureBlobStorage": {
       "ConnectionString": "your-azure-storage-connection-string",
       "ContainerName": "croppilot-images"
     },
     "OpenAI": {
       "ApiKey": "your-openai-api-key",
       "Endpoint": "https://your-azure-openai-endpoint.openai.azure.com/",
       "DeploymentName": "your-deployment-name"
     },
     "Stripe": {
       "PublishableKey": "pk_test_your-stripe-publishable-key",
       "SecretKey": "sk_test_your-stripe-secret-key",
       "WebhookSecret": "whsec_your-webhook-secret"
     },
     "Twilio": {
       "AccountSid": "your-twilio-account-sid",
       "AuthToken": "your-twilio-auth-token",
       "PhoneNumber": "your-twilio-phone-number"
     },
     "MailJet": {
       "ApiKey": "your-mailjet-api-key",
       "ApiSecret": "your-mailjet-api-secret",
       "SenderEmail": "noreply@croppilot.com",
       "SenderName": "Croppilot"
     },
     "GoogleAuth": {
       "ClientId": "your-google-client-id",
       "ClientSecret": "your-google-client-secret"
     },
     "FacebookAuth": {
       "AppId": "your-facebook-app-id",
       "AppSecret": "your-facebook-app-secret"
     },
     "HangfireSettings": {
       "DashboardPath": "/hangfire",
       "Username": "admin",
       "Password": "secure-password",
       "Title": "Croppilot Background Jobs"
     },
     "WatchDogSettings": {
       "WatchPageUsername": "admin",
       "WatchPagePassword": "secure-password"
     },
     "CosmosDb": {
       "ConnectionString": "your-cosmos-db-connection-string",
       "DatabaseName": "CroppilotCosmos",
       "ContainerName": "rover-data"
     },
     "RedisSettings": {
       "ConnectionString": "localhost:6379",
       "InstanceName": "Croppilot"
     }
   }
   ```

   ### 🔑 Required Environment Variables

   For production deployment, set these environment variables:

   ```bash
   # Database
   CONNECTIONSTRINGS__DEFAULT="your-production-db-connection"
   CONNECTIONSTRINGS__REDIS="your-redis-connection"

   # JWT Authentication
   JWTSETTINGS__SECRETKEY="your-jwt-secret-key"

   # Azure Services
   AZUREBLOBSTORAGE__CONNECTIONSTRING="your-azure-storage"
   OPENAI__APIKEY="your-openai-key"

   # Payment
   STRIPE__SECRETKEY="your-stripe-secret"

   # Communications
   TWILIO__AUTHTOKEN="your-twilio-token"
   MAILJET__APIKEY="your-mailjet-key"
   MAILJET__APISECRET="your-mailjet-secret"

   # OAuth
   GOOGLEAUTH__CLIENTSECRET="your-google-secret"
   FACEBOOKAUTH__APPSECRET="your-facebook-secret"
   ```

5. **Run database migrations**

   ```bash
   dotnet ef database update --project Croppilot.Infrastructure --startup-project Croppilot.API
   ```

6. **Start the application**

   ```bash
   dotnet run --project Croppilot.API
   ```

7. **Access the API**
   - API: `https://localhost:7000` or `http://localhost:5000`
   - Swagger Documentation: `https://localhost:7000/swagger`
   - Health Checks: `https://localhost:7000/health`
   - Hangfire Dashboard: `https://localhost:7000/hangfire`

## 📝 API Documentation

The API is fully documented using Swagger/OpenAPI. Access the interactive documentation at `https://localhost:7000/swagger` when running locally.

### 🔐 Authentication & Authorization

```http
# User Registration
POST /api/Authentication/signup
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "SecurePassword123!",
  "confirmPassword": "SecurePassword123!",
  "phoneNumber": "+1234567890"
}

# User Login
POST /api/Authentication/signin
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "SecurePassword123!"
}

# Response
{
  "isSuccess": true,
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "refreshToken": "refresh_token_here",
    "expiresAt": "2024-12-31T23:59:59Z"
  }
}
```

### 🤖 AI Models & Smart Agriculture

```http
# Crop Analysis
POST /api/AIModel/analyze
Authorization: Bearer {token}
Content-Type: multipart/form-data

file: [crop_image.jpg]

# Get AI Recommendations
GET /api/AIModel/feedback?cropType=tomato&soilMoisture=65&temperature=25
Authorization: Bearer {token}

# Watering Recommendations
POST /api/AIModel/watering-feedback
Authorization: Bearer {token}
Content-Type: application/json

{
  "soilMoisture": 45,
  "temperature": 28,
  "humidity": 60,
  "cropType": "wheat",
  "lastWatering": "2024-01-15T08:00:00Z"
}
```

### 🛒 E-Commerce Operations

```http
# List Products with Pagination
GET /api/Product?pageNumber=1&pageSize=10&categoryId=1&sortBy=price&sortOrder=asc
Authorization: Bearer {token}

# Add Product to Cart
POST /api/Cart/add
Authorization: Bearer {token}
Content-Type: application/json

{
  "productId": 123,
  "quantity": 2,
  "specifications": {
    "size": "large",
    "color": "green"
  }
}

# Create Order
POST /api/Order/create
Authorization: Bearer {token}
Content-Type: application/json

{
  "items": [
    {
      "productId": 123,
      "quantity": 2,
      "unitPrice": 29.99
    }
  ],
  "shippingAddress": {
    "street": "123 Farm Road",
    "city": "Agricultural City",
    "zipCode": "12345",
    "country": "USA"
  },
  "paymentMethod": "stripe"
}
```

### 📊 Dashboard & Farm Monitoring

```http
# Get Farm Status
GET /api/Dashboard/farm-status
Authorization: Bearer {token}

# Response
{
  "farmId": "farm_123",
  "overallHealth": "excellent",
  "activeAlerts": 2,
  "equipmentStatus": {
    "online": 15,
    "offline": 2,
    "maintenance": 1
  },
  "currentConditions": {
    "temperature": 25.5,
    "humidity": 68,
    "soilMoisture": 72
  }
}

# Get System Alerts
GET /api/Dashboard/alerts?severity=high&limit=20
Authorization: Bearer {token}

# Submit IoT Sensor Data
POST /api/IoT/sensor-data
Authorization: Bearer {token}
Content-Type: application/json

{
  "deviceId": "sensor_001",
  "timestamp": "2024-01-15T10:30:00Z",
  "measurements": {
    "soilMoisture": 68.5,
    "temperature": 24.2,
    "pH": 6.8,
    "nutrients": {
      "nitrogen": 45,
      "phosphorus": 23,
      "potassium": 67
    }
  }
}
```

### 👥 Social & Community Features

```http
# Create Post
POST /api/Posts
Authorization: Bearer {token}
Content-Type: application/json

{
  "title": "Tips for Organic Tomato Farming",
  "content": "Here are some effective techniques...",
  "tags": ["organic", "tomato", "farming"],
  "images": ["image1.jpg", "image2.jpg"]
}

# Add Product Review
POST /api/Reviews
Authorization: Bearer {token}
Content-Type: application/json

{
  "productId": 123,
  "rating": 5,
  "title": "Excellent Fertilizer",
  "comment": "Great results for my crop yield!",
  "images": ["review_image.jpg"]
}
```

## 💾 Database Schema & Models

### Key Database Entities

The application uses Entity Framework Core with the following main entities:

#### 👤 User Management

- **ApplicationUser**: Extended identity user with farming profile
- **ApplicationRole**: Role-based access control
- **RefreshToken**: JWT refresh token management

#### 🌾 Agricultural Data

- **Farm**: Farm information and ownership
- **Equipment**: IoT devices and farm equipment
- **Alert**: System notifications and warnings
- **SoilData**: Soil analysis and health metrics
- **Weather**: Weather data integration
- **CropYield**: Harvest tracking and analytics

#### 🛒 E-Commerce

- **Product**: Agricultural products and equipment
- **Category**: Product categorization
- **Cart/CartItem**: Shopping cart functionality
- **Order/OrderItem**: Order processing and tracking
- **Payment**: Payment transaction records
- **Coupon**: Discount and promotion management

#### 🤖 AI & Analytics

- **ModelResult**: AI model prediction results
- **FeedbackEntry**: AI recommendation feedback
- **RoverPhoto**: Mars rover educational content

#### 👥 Social Features

- **Post**: Community posts and articles
- **Comment**: Post comments and discussions
- **Review**: Product and service reviews
- **Vote**: Community voting system
- **WishList**: User product wishlist

### Database Migrations

```bash
# Create new migration
dotnet ef migrations add MigrationName --project Croppilot.Infrastructure --startup-project Croppilot.API

# Update database
dotnet ef database update --project Croppilot.Infrastructure --startup-project Croppilot.API

# View migration history
dotnet ef migrations list --project Croppilot.Infrastructure --startup-project Croppilot.API

# Generate SQL script
dotnet ef migrations script --project Croppilot.Infrastructure --startup-project Croppilot.API
```

## 🔒 Security Considerations

### Authentication & Authorization

- **JWT Bearer Tokens**: Stateless authentication with configurable expiration
- **Refresh Tokens**: Secure token renewal mechanism
- **Role-Based Access Control**: Fine-grained permissions system
- **OAuth Integration**: Google and Facebook social login
- **Password Policies**: Strong password requirements with validation

### API Security

- **HTTPS Only**: TLS encryption for all communications
- **CORS Configuration**: Restricted cross-origin requests
- **Rate Limiting**: Protection against abuse and DDoS
- **Input Validation**: Comprehensive request validation using FluentValidation
- **SQL Injection Protection**: Parameterized queries via Entity Framework

### Data Protection

- **Data Encryption**: Sensitive data encryption at rest
- **Connection String Security**: Environment-based configuration
- **File Upload Security**: File type and size validation
- **XSS Protection**: Output encoding and sanitization

### Security Headers

```csharp
// Security headers are automatically configured
app.UseSecurityHeaders(policies =>
{
    policies.AddDefaultSecurityHeaders();
    policies.AddContentSecurityPolicy(builder =>
    {
        builder.AddDefaultSrc().Self();
        builder.AddImageSrc().Self().Data();
    });
});
```

## ⚡ Performance Optimizations

### Caching Strategy

- **Redis Distributed Cache**: High-performance data caching
- **Memory Caching**: Frequently accessed data optimization
- **Response Caching**: API response caching with cache invalidation
- **Custom Cache Attributes**: Declarative caching for methods

### Database Optimization

- **Connection Pooling**: Efficient database connection management
- **Async Operations**: Non-blocking database operations
- **Entity Framework Optimization**:
  - Query splitting for complex includes
  - No-tracking queries for read-only operations
  - Compiled queries for frequently executed operations

### Background Processing

- **Hangfire Integration**: Scalable background job processing
- **Recurring Jobs**: Scheduled tasks for maintenance and analytics
- **Fire-and-Forget Jobs**: Asynchronous operations (emails, notifications)

### Monitoring & Logging

- **Application Insights**: Performance monitoring and analytics
- **Health Checks**: Application and dependency health monitoring
- **WatchDog.NET**: Request/response logging and monitoring
- **Structured Logging**: Serilog integration for better log analysis

## 🧪 Testing

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test Croppilot.Tests.Unit

# Run tests in parallel
dotnet test --parallel
```

### Test Categories

- **Unit Tests**: Business logic and service testing
- **Integration Tests**: API endpoint testing
- **Repository Tests**: Data access layer testing
- **AI Model Tests**: Machine learning model validation
- **Security Tests**: Authentication and authorization testing

### Test Configuration

```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\mssqllocaldb;Database=CroppilotTestDb;Trusted_Connection=true"
  },
  "UseInMemoryDatabase": true
}
```

## 🚨 Troubleshooting

### Common Issues

#### Database Connection Issues

```bash
# Check connection string
dotnet ef database list --project Croppilot.Infrastructure --startup-project Croppilot.API

# Reset database
dotnet ef database drop --project Croppilot.Infrastructure --startup-project Croppilot.API
dotnet ef database update --project Croppilot.Infrastructure --startup-project Croppilot.API
```

#### Migration Issues

```bash
# Remove last migration
dotnet ef migrations remove --project Croppilot.Infrastructure --startup-project Croppilot.API

# Reset to specific migration
dotnet ef database update MigrationName --project Croppilot.Infrastructure --startup-project Croppilot.API
```

#### Redis Connection Issues

```bash
# Test Redis connection
redis-cli ping

# Check Redis logs
docker logs redis-container-name
```

#### AI Model Loading Issues

- Ensure ONNX files are in the `AiModels` folder
- Check file permissions and path configuration
- Verify model file integrity

### Debug Configuration

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.EntityFrameworkCore": "Information",
      "Hangfire": "Warning"
    }
  }
}
```

### Health Check Endpoints

```http
GET /health              # Overall application health
GET /health/ready        # Readiness probe
GET /health/live         # Liveness probe
```

## 🚀 Deployment

### 🐳 Docker Deployment

Create `Dockerfile` in the root directory:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Croppilot.API/Croppilot.API.csproj", "Croppilot.API/"]
COPY ["Croppilot.Core/Croppilot.Core.csproj", "Croppilot.Core/"]
COPY ["Croppilot.Date/Croppilot.Date.csproj", "Croppilot.Date/"]
COPY ["Croppilot.Infrastructure/Croppilot.Infrastructure.csproj", "Croppilot.Infrastructure/"]
COPY ["Croppilot.Services/Croppilot.Services.csproj", "Croppilot.Services/"]

RUN dotnet restore "Croppilot.API/Croppilot.API.csproj"
COPY . .
WORKDIR "/src/Croppilot.API"
RUN dotnet build "Croppilot.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Croppilot.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Croppilot.API/AiModels ./AiModels
ENTRYPOINT ["dotnet", "Croppilot.API.dll"]
```

Create `docker-compose.yml`:

```yaml
version: "3.8"

services:
  croppilot-api:
    build: .
    ports:
      - "5000:80"
      - "5001:443"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__Default=Server=sqlserver;Database=CroppilotDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true
      - ConnectionStrings__Redis=redis:6379
    depends_on:
      - sqlserver
      - redis
    volumes:
      - ./uploads:/app/uploads

  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourStrong!Passw0rd
    ports:
      - "1433:1433"
    volumes:
      - sqlserver_data:/var/opt/mssql

  redis:
    image: redis:7-alpine
    ports:
      - "6379:6379"
    command: redis-server --appendonly yes
    volumes:
      - redis_data:/data

volumes:
  sqlserver_data:
  redis_data:
```

### ☁️ Azure Deployment

#### Azure App Service

```bash
# Login to Azure
az login

# Create resource group
az group create --name croppilot-rg --location "East US"

# Create app service plan
az appservice plan create --name croppilot-plan --resource-group croppilot-rg --sku B1

# Create web app
az webapp create --name croppilot-api --resource-group croppilot-rg --plan croppilot-plan --runtime "DOTNETCORE|8.0"

# Configure connection strings
az webapp config connection-string set --name croppilot-api --resource-group croppilot-rg --connection-string-type SQLAzure --settings DefaultConnection="YourConnectionString"

# Deploy
dotnet publish -c Release
cd bin/Release/net8.0/publish
zip -r deploy.zip .
az webapp deployment source config-zip --name croppilot-api --resource-group croppilot-rg --src deploy.zip
```

#### Azure Container Instances

```bash
# Build and push to Azure Container Registry
az acr create --resource-group croppilot-rg --name croppilotacr --sku Basic
az acr login --name croppilotacr
docker build -t croppilotacr.azurecr.io/croppilot-api:latest .
docker push croppilotacr.azurecr.io/croppilot-api:latest

# Deploy to ACI
az container create --resource-group croppilot-rg --name croppilot-container --image croppilotacr.azurecr.io/croppilot-api:latest --cpu 2 --memory 4 --ports 80
```

### 🚀 Production Configuration

Create `appsettings.Production.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning",
      "System": "Warning"
    }
  },
  "AllowedHosts": ["yourdomain.com", "api.yourdomain.com"],
  "UseHsts": true,
  "UseHttpsRedirection": true,
  "Security": {
    "EnforceSSL": true,
    "RequireHttps": true
  }
}
```

### 📊 Monitoring & Analytics

#### Application Insights Setup

```json
{
  "ApplicationInsights": {
    "ConnectionString": "InstrumentationKey=your-instrumentation-key"
  },
  "Logging": {
    "ApplicationInsights": {
      "LogLevel": {
        "Default": "Information"
      }
    }
  }
}
```

#### Health Check Configuration

```csharp
services.AddHealthChecks()
    .AddSqlServer(connectionString)
    .AddRedis(redisConnection)
    .AddAzureBlobStorage(blobStorageConnection)
    .AddHangfire(options => options.MaximumJobsFailed = 5);
```

## 👨‍💻 Development Workflow

### Git Workflow

1. **Feature Branch**: Create feature branches from `develop`

   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b feature/crop-analysis-improvement
   ```

2. **Development**: Make changes and commit frequently

   ```bash
   git add .
   git commit -m "feat: improve crop disease detection accuracy"
   ```

3. **Pull Request**: Create PR to `develop` branch

   - Add descriptive title and description
   - Include screenshots for UI changes
   - Reference related issues

4. **Code Review**: Address feedback and update PR

5. **Merge**: Squash and merge to `develop`

6. **Release**: Merge `develop` to `main` for releases

### Code Standards

#### Naming Conventions

- **Classes**: PascalCase (`ProductService`, `AIModelController`)
- **Methods**: PascalCase (`GetProductsByCategory`, `AnalyzeCropImage`)
- **Variables**: camelCase (`productId`, `userEmail`)
- **Constants**: UPPER_SNAKE_CASE (`MAX_FILE_SIZE`, `DEFAULT_PAGE_SIZE`)
- **Private Fields**: \_camelCase (`_logger`, `_productRepository`)

#### Code Quality Tools

```bash
# Install tools
dotnet tool install -g dotnet-ef
dotnet tool install -g dotnet-format
dotnet tool install -g dotnet-outdated-tool

# Format code
dotnet format

# Check for outdated packages
dotnet outdated

# Run static analysis
dotnet build --verbosity normal /p:WarningLevel=5
```

### Pre-commit Hooks

Create `.githooks/pre-commit`:

```bash
#!/bin/sh
# Run code formatting
dotnet format --verify-no-changes

# Run tests
dotnet test --no-build --verbosity quiet

# Check for security vulnerabilities
dotnet list package --vulnerable --include-transitive
```

## 🤝 Contributing

We welcome contributions! Please follow these guidelines:

### 🐛 Bug Reports

Include the following in bug reports:

- Clear description of the issue
- Steps to reproduce
- Expected vs actual behavior
- Environment details (OS, .NET version, etc.)
- Screenshots or logs if applicable

### ✨ Feature Requests

- Describe the feature and its benefits
- Provide use cases and examples
- Consider backward compatibility
- Discuss implementation approach

### 🔄 Pull Requests

1. **Fork the repository**
2. **Create a feature branch** from `develop`
3. **Write clear commit messages** following [Conventional Commits](https://conventionalcommits.org/)
4. **Add tests** for new functionality
5. **Update documentation** as needed
6. **Ensure CI passes** before submitting
7. **Request review** from maintainers

### 📝 Commit Message Format

```
type(scope): description

[optional body]

[optional footer]
```

Examples:

- `feat(ai): add crop disease detection model`
- `fix(auth): resolve JWT token expiration issue`
- `docs(readme): update API documentation`
- `test(product): add unit tests for product service`

### Code Review Checklist

- [ ] Code follows project conventions
- [ ] Tests are included and passing
- [ ] Documentation is updated
- [ ] No breaking changes without migration path
- [ ] Performance implications considered
- [ ] Security implications reviewed

## ⚙️ CI/CD Pipeline

### GitHub Actions

Create `.github/workflows/ci.yml`:

```yaml
name: CI/CD Pipeline

on:
  push:
    branches: [main, develop]
  pull_request:
    branches: [main, develop]

jobs:
  build-and-test:
    runs-on: ubuntu-latest

    services:
      sqlserver:
        image: mcr.microsoft.com/mssql/server:2022-latest
        env:
          ACCEPT_EULA: Y
          SA_PASSWORD: Test@123456
        ports:
          - 1433:1433
        options: >-
          --health-cmd "/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Test@123456 -Q 'SELECT 1'"
          --health-interval 10s
          --health-timeout 5s
          --health-retries 5

    steps:
      - uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 8.0.x

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore --configuration Release

      - name: Test
        run: dotnet test --no-build --verbosity normal --configuration Release --collect:"XPlat Code Coverage"

      - name: Upload coverage reports
        uses: codecov/codecov-action@v3
        with:
          files: ./coverage.cobertura.xml
          fail_ci_if_error: true
```

## 📋 Project Roadmap

### ✅ Completed Features

- [x] User authentication and authorization
- [x] AI-powered crop analysis
- [x] E-commerce platform with payment integration
- [x] Real-time farm monitoring dashboard
- [x] Social community features
- [x] Mars rover data integration
- [x] Comprehensive health monitoring

### 🚧 In Progress

- [ ] Mobile app integration APIs
- [ ] Advanced AI model training pipeline
- [ ] Multi-tenant architecture
- [ ] Real-time WebSocket notifications

### 🔮 Future Plans

- [ ] Blockchain integration for supply chain tracking
- [ ] Drone integration for aerial monitoring
- [ ] Advanced weather prediction models
- [ ] IoT device management platform
- [ ] Machine learning model marketplace

## 📊 Performance Metrics

### Benchmarks

- **Response Time**: < 200ms for 95% of requests
- **Throughput**: 1000+ requests/second
- **Uptime**: 99.9% availability target
- **Database Queries**: < 50ms average execution time

## 📞 Support & Community

### 📧 Contact Information

- **Technical Support**: tech-support@croppilot.com
- **Business Inquiries**: business@croppilot.com
- **Security Issues**: security@croppilot.com

### 🌐 Community Links

- 🐛 **Bug Reports**: [GitHub Issues](https://github.com/Smart-Farming-Graduation-Project/Back-End/issues)
- 💬 **Discussions**: [GitHub Discussions](https://github.com/Smart-Farming-Graduation-Project/Back-End/discussions)
- 📖 **Documentation**: [Project Wiki](https://github.com/Smart-Farming-Graduation-Project/Back-End/wiki)

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

### Third-Party Licenses

- Microsoft.ML.OnnxRuntime - MIT License
- Hangfire - LGPL v3
- Redis - BSD 3-Clause
- Entity Framework Core - MIT License

## 🙏 Acknowledgments

- **Microsoft**: For .NET 8.0 and Azure services
- **NASA**: Mars rover data and educational content
- **Open Source Community**: For amazing packages and tools
- **Contributors**: Everyone who helped make this project better
- **Agriculture Experts**: For domain knowledge and guidance

---

<div align="center">

**🌱 Made with ❤️ for sustainable agriculture and modern farming solutions 🌱**

[![Star this repo](https://img.shields.io/github/stars/Smart-Farming-Graduation-Project/Back-End?style=social)](https://github.com/Smart-Farming-Graduation-Project/Back-End)

_Building the future of smart agriculture, one commit at a time._

</div>
