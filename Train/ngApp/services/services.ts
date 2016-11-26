namespace MyApp.Services {

    export class CarService {
        private CarResource;
        private UserProfileResource;

        public listCars() {
            return this.CarResource.query();
        }
        
        public get(id: number) {
            return this.CarResource.get({ id: id })
        }
        public save(carToSave, recordId) {
            var data: any = {};
            data.carToSave = carToSave;
            data.recordId = recordId;
            return this.CarResource.save(data).$promise

        }
        public listUserCars(userId) {
            return this.UserProfileResource.query({ userId: userId });
        }
       
        constructor($resource: angular.resource.IResourceService, private $window: ng.IWindowService) {
            this.CarResource = $resource('/api/cars/:id');
            this.UserProfileResource = $resource('api/cars/userProfile/:userId');
        }
    }

    angular.module('MyApp').service('carService', CarService);

    export class RecordService {
        private RecordResource;
        //public UserProfileResource;

        public save(record) {
            debugger
            return this.RecordResource.save(record).$promise;
        }
        public get(id: number) {
            return this.RecordResource.get({ id: id })

        }
        constructor($resource: angular.resource.IResourceService, private $window: ng.IWindowService) {
            this.RecordResource = $resource('/api/record/:id');
            //this.UserProfileResource = $resource('api/cars/userProfile/:userId');

        }
    }
    angular.module('MyApp').service('recordService', RecordService);
}