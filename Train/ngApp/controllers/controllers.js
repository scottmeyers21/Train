var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController(carService, $location) {
                this.carService = carService;
                this.$location = $location;
                this.cars = this.carService.listCars();
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
                this.carService.save(this.newCar).then(function () { _this.$location.path('/'); });
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
        var AboutController = (function () {
            function AboutController() {
            }
            return AboutController;
        }());
        Controllers.AboutController = AboutController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=controllers.js.map