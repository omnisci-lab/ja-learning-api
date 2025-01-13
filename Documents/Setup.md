## ⚙️ **Setup & Installation**

### 1️⃣ **Clone the repository**

```bash
git clone --recurse-submodules https://github.com/omnisci-lab/ja-learning-api.git
cd ja-learning-api
```

### 2️⃣ **Install Dependencies**

Ensure you have the following installed:

- **.NET SDK 9.0**
- **MongoDB Server**
- **Redis Server**

### 3️⃣ **Configure Environment**

Create an `appsettings.Development.json` with the following configuration:

```json
{
  "ConnectionStrings": {
    "RedisConnection": "localhost:6379,abortConnect=false"
  },
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "Japanese"
  },
  "CORS": {
    "Origin": "http://localhost:4200"
  },
  "DistributedCacheSettings": {
    "AbsoluteExpiration": "30"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 4️⃣ **Run the application**

```bash
dotnet run
```

The API will be available at: `http://localhost:5000`