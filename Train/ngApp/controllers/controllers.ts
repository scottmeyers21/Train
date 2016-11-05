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
        public save() {
            this.carService.save(this.newCar).then(() => this.newCar = {}); 
        }
        public cancel() {
            this.newCar = {};
        }
        constructor(
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService
        ) { }

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
            this.recordService.save(this.newRecord).then(() => this.newRecord = {});
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