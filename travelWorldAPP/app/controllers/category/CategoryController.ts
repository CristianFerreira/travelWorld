/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class CategoryController {

        static $inject = ['$location', 'CategoryService', 'toastr', '$mdDialog', '$timeout'];

     
        private $location: ILocationService;
        private categoryService: CategoryService;
        public categorys: Array<Category>;
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
                    categoryService: CategoryService, 
                    toastr: Toastr,
                    mdDialog: any,
                    timeout: ITimeoutService) {

            this.$location = $location;
            this.categoryService = categoryService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.timeout = timeout;
            this.categorys = new Array<Category>();
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

            this.loadCategory();
        }

        public loadCategory() : void {
           this.categoryService.listAll()
                .then((data) => {                 
                    this.categorys = data;                               
                })
                .catch((response) => console.log("Não carregou as categorias, erro: " + response));
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
        }, 500);
    }


     public modalCreateCategory (ev: any) : void {
         this.mdDialog.show({
            controller: "ModalCreateController",
            templateUrl: 'app/views/categoria/modal-create-category.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm'
        }).finally( () => {
            this.loadCategory();
             this.loadStuff();
        });
     } 

       public modalEditCategory (ev: any, category: Category) : void {
         this.mdDialog.show({
            controller: "ModalEditController",
            templateUrl: 'app/views/categoria/modal-edit-category.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             category: ()=> category
                     }
        }).finally( () => {           
            this.selected = new Array<any>();
            this.loadCategory();
            this.loadStuff();
        });
     } 

    public modalDeleteCategory (ev: any, deleteCategorys: Array<Category>) : void {
         this.mdDialog.show({
           controller: "ModalDeleteController",
            templateUrl: 'app/views/categoria/modal-delete-category.html',
            targetEvent: ev,
            clickOutsideToClose: true,
            controllerAs: 'vm',
            resolve: {
                             deleteCategorys: ()=> deleteCategorys
                     }
        }).finally( () => {         
            this.selected = new Array<any>(); 
            this.loadCategory();
            this.loadStuff();
        });
     } 
    }

    angular.module(appConfig.appName).controller('CategoryController', CategoryController);
}