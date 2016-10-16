var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var CarService = (function () {
            function CarService($resource) {
                this.CarResource = $resource('/api/cars/:id');
            }
            CarService.prototype.listCars = function () {
                return this.CarResource.query();
            };
            CarService.prototype.save = function (car) {
                return this.CarResource.save(car).$promise;
            };
            return CarService;
        }());
        Services.CarService = CarService;
        angular.module('MyApp').service('carService', CarService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=services.js.map