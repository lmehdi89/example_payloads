# Power Plant Production Plan API

This API calculates the production plan for power plants based on the given payload.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://docs.docker.com/get-docker/)

## Build and Launch

### Local Installation

1. Clone this repository:

    ```bash
    git clone https://github.com/lmehdi89/example_payloads.git
    ```

2. Navigate to the project directory:

    ```bash
    cd example_payloads
    ```

3. Build the application:

    ```bash
    dotnet build
    ```

4. Run the application:

    ```bash
    dotnet run --project example_payloads
    ```

The API will be accessible at http://localhost:5000.

### Docker Installation

1. Pull the Docker image from Docker Hub:

    ```bash
    docker pull lmehdi/aspnetapp
    ```

2. Run the Docker container:

    ```bash
    docker run -p 8888:80 lmehdi/aspnetapp
    ```

The API will be accessible at http://localhost:8888.

## API Endpoint

### POST /productionplan

This endpoint accepts a JSON payload containing load and power plant information and returns the production plan.

Example payload:

```json
{
  "load": 50,
  "fuels": {
    "gas": 10,
    "kerosine": 20,
    "co2": 5,
    "wind": 30
  },
  "powerplants": [
    {
      "name": "gas_plant",
      "type": "gasfired",
      "efficiency": 0.5,
      "pmax": 100,
      "pmin": 10
    },
    {
      "name": "wind_turbine",
      "type": "windturbine",
      "efficiency": 1.0,
      "pmax": 200,
      "pmin": 0
    }
  ]
}
```