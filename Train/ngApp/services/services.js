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
            CarService.prototype.get = function (id) {
                return this.CarResource.get({ id: id });
            };
            CarService.prototype.save = function (carToSave, recordId) {
                var data = {};
                data.carToSave = carToSave;
                data.recordId = recordId;
                return this.CarResource.save(data).$promise;
            };
            CarService.prototype.listUserCars = function (userId) {
                return this.UserProfileResource.query({ userId: userId });
            };
            return CarService;
        }());
        Services.CarService = CarService;
        angular.module('MyApp').service('carService', CarService);
        var RecordService = (function () {
            function RecordService($resource, $window) {
                this.$window = $window;
                this.RecordResource = $resource('/api/record/:id');
                //this.UserProfileResource = $resource('api/cars/userProfile/:userId');
            }
            //public UserProfileResource;
            RecordService.prototype.save = function (record) {
                debugger;
                return this.RecordResource.save(record).$promise;
            };
            RecordService.prototype.get = function (id) {
                return this.RecordResource.get({ id: id });
            };
            return RecordService;
        }());
        Services.RecordService = RecordService;
        angular.module('MyApp').service('recordService', RecordService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=services.js.map