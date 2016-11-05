var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var CarService = (function () {
            function CarService($resource, $window) {
                this.$window = $window;
                this.CarResource = $resource('/api/cars/:id');
                this.UserProfileResource = $resource('api/cars/userProfile/:userId');
            }
            CarService.prototype.listCars = function () {
                return this.CarResource.query();
            };
            CarService.prototype.listUserCars = function (userId) {
                return this.UserProfileResource.query({ userId: userId });
            };
            CarService.prototype.save = function (car) {
                return this.CarResource.save(car).$promise;
            };
            return CarService;
        }());
        Services.CarService = CarService;
        angular.module('MyApp').service('carService', CarService);
        var RecordService = (function () {
            function RecordService($resource, $window) {
                this.$window = $window;
                this.RecordResource = $resource('/api/record/:id');
                this.UserProfileResource = $resource('api/cars/userProfile/:userId');
            }
            RecordService.prototype.save = function (record) {
                return this.RecordResource.save(record).$promise;
            };
            return RecordService;
        }());
        Services.RecordService = RecordService;
        angular.module('MyApp').service('recordService', RecordService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=services.js.map