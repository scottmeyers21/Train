var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController() {
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
        var AddCarController = (function () {
            function AddCarController(carService, $location) {
                this.carService = carService;
                this.$location = $location;
            }
            AddCarController.prototype.save = function () {
                var _this = this;
                this.carService.save(this.newCar).then(function () { return _this.newCar = {}; });
            };
            AddCarController.prototype.cancel = function () {
                this.newCar = {};
            };
            return AddCarController;
        }());
        Controllers.AddCarController = AddCarController;
        var ModIncomingController = (function () {
            function ModIncomingController(carService, $location) {
                this.carService = carService;
                this.$location = $location;
                this.cars = this.carService.listCars();
            }
            return ModIncomingController;
        }());
        Controllers.ModIncomingController = ModIncomingController;
        var UserProfileController = (function () {
            function UserProfileController(carService, $location, $routeParams, $window) {
                this.carService = carService;
                this.$location = $location;
                this.$window = $window;
                this.cars = this.carService.listUserCars($routeParams['userId']);
            }
            return UserProfileController;
        }());
        Controllers.UserProfileController = UserProfileController;
        var AddRecordController = (function () {
            function AddRecordController(recordService, $location) {
                this.recordService = recordService;
                this.$location = $location;
            }
            AddRecordController.prototype.save = function () {
                var _this = this;
                this.recordService.save(this.newRecord).then(function () { return _this.newRecord = {}; });
            };
            AddRecordController.prototype.cancel = function () {
                this.newRecord = {};
            };
            return AddRecordController;
        }());
        Controllers.AddRecordController = AddRecordController;
        var AboutController = (function () {
            function AboutController() {
            }
            return AboutController;
        }());
        Controllers.AboutController = AboutController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=controllers.js.map