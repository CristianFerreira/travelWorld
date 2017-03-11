/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class CityController {

        static $inject = ['$location', 'CityService', 'ContinentService', 'toastr', '$mdDialog', '$timeout'];

     
        private $location: ILocationService;     
        private cityService: CityService;
        private continentService: ContinentService;
        public toastr: Toastr;
        public mdDialog: any;
        public timeout: ITimeoutService;
        public selected: Array<any>;
        public limitOptions: Array<any>;
        public options: any;
        public query: any;
        public showCheck: any;
        public promise: any;
        public filterShow: boolean;
        public filterSearch: string;
        public continents: Array<Continent>;
        public cities: Array<City>;



        constructor($location: ILocationService,                    
                    cityService: CityService,
                    continentService: ContinentService,
                    toastr: Toastr,
                    mdDialog: any,
                    timeout: ITimeoutService) {

            this.$location = $location;
            this.cityService = cityService;
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.timeout = timeout;
            this.cities = new Array<City>();
            this.continents = new Array<Continent>();
            this.selected =  [];
            this.limitOptions = [5, 10, 15];
            this.options = {
                             rowSelection: true,
                             multiSelect: true,
                             autoSelect: true,
                             decapitate: false,
                             largeEditDialog: false,
                             boundaryLinks: true,
                             limitSelect: true,
                             pageSelect: true
            };
            this.query = {
                            order: 'name',
                            limit: 5,
                            page: 1
            };
            this.showCheck = {};
            this.loadCity();                    
            this.loadContinents();
        }

        public loadCity() : void {
           this.cityService.listAll()
                .then((data) => {                 
                    this.cities = data;                         
                })
                .catch((response) => console.log("Não carregou as cidades, erro: " + response));
        }

        public removeFilter () : void {
        this.filterShow = false;
        this.filterSearch = '';
    };

       public toggleLimitOptions () : any {
             this.limitOptions = this.limitOptions ? undefined : [5, 10, 15];
        };

       public loadStuff () : any {
            this.promise = this.timeout(function () {
            // loading
        }, 300);
    }

     public loadContinents() :void{
           this.continentService.listAll()
                .then((data) => {                 
                    this.continents = data;                             
                })
                .catch((response) => console.log("Não carregou os continents, erro: " + response));
    }

     public modalCreateCity (ev: any) : void {
         this.mdDialog.show({
            controller: "ModalCreateCityController",
            templateUrl: 'app/views/city/modal-create-city.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
             resolve: {
                             continents: () => this.continents
                     }
        }).finally( () => {
            this.loadContinents();
            this.loadCity();   
            this.loadStuff();
        });
     } 

       public modalEditCity  (ev: any, city: City) : void {
         this.mdDialog.show({
            controller: "ModalEditCityController",
            templateUrl: 'app/views/country/modal-edit-country.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             continents: ()=> this.continents,
                             city: ()=> city
                     }
        }).finally((data) => { 
            this.loadCity();
            this.loadContinents();       
            this.selected = new Array<any>();        
            this.loadStuff();
        });
     } 

    public modalDeleteCity  (ev: any, deleteCities: Array<City>) : void {
         this.mdDialog.show({
           controller: "ModalDeleteCityController",
            templateUrl: 'app/views/city/modal-delete-city.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             deleteCities: ()=> deleteCities
                     }
        }).finally( (data) => {
            this.loadCity();
            this.loadContinents();   
            this.loadStuff();                 
            this.selected = new Array<any>();           
        });
     } 
    }

    angular.module(appConfig.appName).controller('CityController', CityController);
}