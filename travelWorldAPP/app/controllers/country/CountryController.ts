/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class CountryController {

        static $inject = ['$location', 'CountryService', 'ContinentService', 'toastr', '$mdDialog', '$timeout'];

     
        private $location: ILocationService;
        private countryService: CountryService;
        private continentService: ContinentService;
        public countries: Array<Country>;
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

        constructor($location: ILocationService, 
                    countryService: CountryService, 
                    continentService: ContinentService,
                    toastr: Toastr,
                    mdDialog: any,
                    timeout: ITimeoutService) {

            this.$location = $location;
            this.countryService = countryService;
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.timeout = timeout;
            this.countries = new Array<Country>();
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
            this.continents = new Array<Continent>();
            this.loadCountry();
            this.loadContinents();
        }

        public loadCountry() : void {
           this.countryService.listAll()
                .then((data) => {                 
                    this.countries = data; 
                          
                })
                .catch((response) => console.log("Não carregou os continents, erro: " + response));
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


     public modalCreateCountry (ev: any) : void {
         var continents = this.continents
         this.mdDialog.show({
            controller: "ModalCreateCountryController",
            templateUrl: 'app/views/country/modal-create-country.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
             resolve: {
                             continents: ()=> continents
                     }
        }).finally( () => {
            this.loadCountry();
            this.loadContinents();   
            this.loadStuff();
        });
     } 

       public modalEditCountry  (ev: any, country: Country) : void {
         this.mdDialog.show({
            controller: "ModalEditCountryController",
            templateUrl: 'app/views/country/modal-edit-country.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             country: ()=> country,
                             continents: ()=> this.continents
                     }
        }).finally((data) => { 
            this.loadCountry();   
            this.loadContinents();       
            this.selected = new Array<any>();        
            this.loadStuff();
        });
     } 

    public modalDeleteCountry  (ev: any, deleteCountries: Array<Country>) : void {
         this.mdDialog.show({
           controller: "ModalDeleteCountryController",
            templateUrl: 'app/views/country/modal-delete-country.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             deleteCountries: ()=> deleteCountries
                     }
        }).finally( (data) => {
            this.loadCountry(); 
            this.loadContinents();   
            this.loadStuff();                 
            this.selected = new Array<any>();           
        });
     } 
    }

    angular.module(appConfig.appName).controller('CountryController', CountryController);
}