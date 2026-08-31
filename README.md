[![](https://img.shields.io/nuget/v/soenneker.netlify.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.netlify.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.netlify.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.netlify.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.netlify.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.netlify.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.netlify.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.netlify.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Netlify.OpenApiClientUtil

Provides a configured Netlify API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Netlify.OpenApiClientUtil
```

## Configuration

```json
{
  "Netlify": {
    "ApiKey": "your-access-token"
  }
}
```

## Usage

```csharp
using Soenneker.Netlify.OpenApiClientUtil.Abstract;
using Soenneker.Netlify.OpenApiClientUtil.Registrars;

services.AddNetlifyOpenApiClientUtilAsSingleton();

INetlifyOpenApiClientUtil netlify = serviceProvider
    .GetRequiredService<INetlifyOpenApiClientUtil>();

var client = await netlify.Get(cancellationToken);
var user = await client.User.GetAsync(cancellationToken: cancellationToken);
```

Use `AddNetlifyOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
