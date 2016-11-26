namespace MyApp.Controllers {

    export class HomeController {
        //public cars;

        //constructor
        //(
        //    private carService: MyApp.Services.CarService,
        //    private $location: angular.ILocationService
        //) {
        //    this.cars = this.carService.listCars();
        //}

    }
    export class AddCarController {
        public newCar;
        public record;
        public id;
        public cars;

        public save() {
            this.carService.save(this.newCar, this.record.id).then(() => {
                this.newCar = {}, this.record = this.recordService.get(this.record.id);
            });
        //}
        //public cancel() {
        //    this.newCar = {};
        }
        constructor(
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService,
            private recordService: MyApp.Services.RecordService,
            $routeParams: ng.route.IRouteParamsService
        ) {
            this.record = this.recordService.get($routeParams["id"]);
            this.cars = this.record.cars;
        }

    }
    export class ModIncomingController {
        public cars;

        constructor
            (
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService
            ) {
            this.cars = this.carService.listCars();
        }
    }
    export class UserProfileController {
        public cars;

        constructor
            (
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService,
            $routeParams: ng.route.IRouteParamsService,
            private $window: ng.IWindowService
            ) {
            this.cars = this.carService.listUserCars($routeParams['userId']);
        }

    }
    export class AddRecordController {
        public newRecord;
        public save() {
            this.recordService.save(this.newRecord).then(() => { this.$location.path("/addCarPage") });
        }
        public cancel() {
            this.newRecord = {};
        }
        constructor(
            private recordService: MyApp.Services.RecordService,
            private $location: angular.ILocationService
        ) { }

    }

    export class AboutController {

    }
    
}