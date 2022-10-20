# Bitcoin Price Presenter

This is the sample application that I made for your assignment. It fetches the prices from the sources that you listed and saves them in a localdb. 

## Project structure

The project consists of 6 projects

1. *BitcoinPricePresenter*: It's the main executable project. It starts a new WebApi as it runs. There is one controller `BitcoinPriceController` and it's parent `BaseController`. The first has the endpoints that are asked. As the application starts, the user gets redirected in `Swagger` URL. 
2. *BitcoinPresenter.Abstractions*: It contains all abstractions eg service interfaces that are used by the main application along with the models.
3. *BitcoinPresenter.Concrete*: It contains the implementations of the interfaces that are defined in the *BitcoinPresenter.Abstractions* 
4. *BitcoinPresenter.Data.Abstractions*: All service interfaces that are used in order to handle database data
5. *BitcoinPresenter.Data*: The implementations of services that are defined in *BitcoinPresenter.Data.Abstractions*
6. *BitcoinPresenter.Tests*: Contains some unit tests that assure some execution flows in the project.

## Packages used 

To create this project the packages that I used, except the already added by the initial bootstrapping, are the following:

- *Automapper*: For mapping between objects
- *FluentValidation*: For validation of the requests that are sent to the API
- *Polly*: For adding retry policies for the HTTP Clients used
- *System.Text.Json*: For serialization and deserialization of Json objects sent from and to the API
- *AutoFixture* with *AutoFixture.Moq*: For creating the XUnit Unit tests
- *Entity Framework*: For a datasource

## Usage examples

1. There is a HTTP GET request in order to list the available sources with their names and Base URLs
2. In order to get the current price from a source, an HTTP POST request is being issued and when the response is being fetched, it is being saved in the database. The only argument for this call is the source and it's a route parameter. An object is being returned containing the Id, the price, the timestamp and source of the price
3. In order to get the history of prices, an HTTP POST request is being issued containing the following elements:
- The date range for which we 're searching for
- The max number of items and the page in order to support pagination

A list of objects is being returned by this call.

## Version History

- v.1.0.0: A first working version containing all the requested functionality, using EF in-memory database
- v.1.0.1: Some cleanup and added validation
- v.1.0.2: Added EF Core with a database and containerization with `docker-compose`. To be honest even if I managed to deploy it in docker desktop, I was not able to access it from the browser, as I was getting an HTTP 404 error. No traffic is being routed to the container via `localhost:8000` that I map.
- v.1.0.3: Applied some fixes and provide this `README.md` file

