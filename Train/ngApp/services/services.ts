namespace MyApp.Services {

    export class CarService {
        private CarResource;
        private UserProfileResource;

        public listCars() {
            return this.CarResource.query();
        }
        public listUserCars(userId) {
            return this.UserProfileResource.query({ userId: userId });
        }
        public save(car) {
            return this.CarResource.save(car).$promise;
        }
        constructor($resource: angular.resource.IResourceService, private $window: ng.IWindowService) {
            this.CarResource = $resource('/api/cars/:id');
            this.UserProfileResource = $resource('api/cars/userProfile/:userId');
        }
    }

    angular.module('MyApp').service('carService', CarService);

    export class RecordService {
        private RecordResource;
        public UserProfileResource;

        public save(record) {
            return this.RecordResource.save(record).$promise;
        }
        constructor($resource: angular.resource.IResourceService, private $window: ng.IWindowService) {
            this.RecordResource = $resource('/api/record/:id');
            this.UserProfileResource = $resource('api/cars/userProfile/:userId');

        }
    }
    angular.module('MyApp').service('recordService', RecordService)
}