/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class ContinentController {

        static $inject = ['$location', 'ContinentService', 'toastr', '$mdDialog', '$timeout'];

     
        private $location: ILocationService;
        private continentService: ContinentService;
        public continents: Array<Continent>;
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

        constructor($location: ILocationService, 
                    continentService: ContinentService, 
                    toastr: Toastr,
                    mdDialog: any,
                    timeout: ITimeoutService) {

            this.$location = $location;
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.timeout = timeout;
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

            this.loadContinent();
        }

        public loadContinent() : void {
           this.continentService.listAll()
                .then((data) => {                 
                    this.continents = data;                               
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


     public modalCreateContinent (ev: any) : void {
         this.mdDialog.show({
            controller: "ModalCreateContinentController",
            templateUrl: 'app/views/continent/modal-create-continent.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm'
        }).finally( () => {
            this.loadContinent();
            this.loadStuff();
        });
     } 

       public modalEditContinent (ev: any, continent: Continent) : void {
         this.mdDialog.show({
            controller: "ModalEditContinentController",
            templateUrl: 'app/views/continent/modal-edit-continent.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             continent: ()=> continent
                     }
        }).finally((data) => { 
            this.loadContinent();          
            this.selected = new Array<any>();        
            this.loadStuff();
        });
     } 

    public modalDeleteContinent (ev: any, deleteContinents: Array<Continent>) : void {
         this.mdDialog.show({
           controller: "ModalDeleteContinentController",
            templateUrl: 'app/views/continent/modal-delete-continent.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             deleteContinents: ()=> deleteContinents
                     }
        }).finally( (data) => {
            this.loadContinent(); 
            this.loadStuff();                 
            this.selected = new Array<any>();           
        });
     } 
    }

    angular.module(appConfig.appName).controller('ContinentController', ContinentController);
}