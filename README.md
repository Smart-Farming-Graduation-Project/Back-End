# 🌱 Croppilot Backend

A comprehensive agricultural management platform backend built with .NET 8.0, featuring AI-powered crop management, IoT integration, and e-commerce capabilities for modern farming solutions.

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

## 🏗️ Architecture

The project follows **Clean Architecture** principles with clear separation of concerns:

```
📦 Croppilot Backend
├── 🎯 Croppilot.API          # Presentation Layer
├── 🧠 Croppilot.Core         # Application Layer (CQRS + MediatR)
├── 📊 Croppilot.Data         # Domain Layer (Entities & DTOs)
├── 🔧 Croppilot.Services     # External Services Layer
└── 🏗️ Croppilot.Infrastructure # Infrastructure Layer (Data Access)
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

4. **Set up external services** (Optional but recommended)

   Configure the following in `appsettings.json`:

   - Azure Blob Storage
   - Azure OpenAI
   - Stripe payment keys
   - Twilio credentials
   - MailJet settings
   - Google/Facebook OAuth

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

The API is fully documented using Swagger/OpenAPI. Key controller endpoints include:

### Authentication & Authorization

- `POST /api/Authentication/signin` - User login
- `POST /api/Authentication/signup` - User registration
- `POST /api/Authentication/refresh-token` - Token refresh
- `GET /api/Authorization/roles` - Role management

### AI Models

- `POST /api/AIModel/analyze` - Crop analysis
- `GET /api/AIModel/feedback` - Get AI feedback
- `POST /api/AIModel/watering-feedback` - Watering recommendations

### E-Commerce

- `GET /api/Product` - List products
- `POST /api/Cart/add` - Add to cart
- `POST /api/Order/create` - Create order
- `POST /api/Payment/process` - Process payment

### Dashboard & IoT

- `GET /api/Dashboard/farm-status` - Farm status
- `GET /api/Dashboard/alerts` - System alerts
- `POST /api/IoT/sensor-data` - IoT data ingestion

## 🧪 Testing

Run the test suite:

```bash
dotnet test
```

## 🚀 Deployment

### Production Configuration

1. Update `appsettings.Production.json` with production values
2. Configure environment variables for sensitive data
3. Set up CI/CD pipeline (GitHub Actions, Azure DevOps)
4. Deploy to Azure App Service, AWS, or your preferred platform

### Docker Support

```dockerfile
# Add Dockerfile for containerized deployment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Croppilot.API.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

For support and questions:

- 📧 Email: support@croppilot.com
- 🐛 Issues: [GitHub Issues](https://github.com/your-username/croppilot-backend/issues)
- 📖 Documentation: [Wiki](https://github.com/your-username/croppilot-backend/wiki)

## 🔄 Version History

- **v1.0.0** - Initial release with core features
- **v1.1.0** - Added AI model integration
- **v1.2.0** - Enhanced dashboard capabilities
- **v1.3.0** - Added e-commerce functionality

---

Made with ❤️ for sustainable agriculture and modern farming solutions.
