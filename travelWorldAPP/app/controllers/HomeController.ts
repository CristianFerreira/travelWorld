/// <reference path="../configs/_all.ts" />
module Travel_World {
    export class HomeController {

        static $inject = [];

         public selected: Array<any>;
        public limitOptions: Array<any>;
        public options: any;
        public query: any;
        public showCheck: any;
        public promise: any;
        public filterShow: boolean;
        public filterSearch: string;

        public paging: any;
        public currentPage: any;

        
        public imagePath: Array<string>;

        constructor() {
         this.imagePath = new Array<string>();   
         this.imagePath.push('app/assets/img/teste/foto6.jpg');
         this.imagePath.push('app/assets/img/teste/foto2.jpg'); 
         this.imagePath.push('app/assets/img/teste/foto3.jpg'); 
         this.imagePath.push('app/assets/img/teste/foto4.jpg'); 
         this.imagePath.push('app/assets/img/teste/foto7.jpg'); 
         this.imagePath.push('app/assets/img/teste/foto8.jpg'); 
         this.imagePath.push('app/assets/img/teste/foto9.jpg'); 

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

            this.currentPage = 0;
             this.paging = {
                             total: 100,
                               current: 1
             };
              
        }   

    public loadPages() : any {
    console.log('Current page is : ' + this.paging.current);

    // TODO : Load current page Data here
    
    this.currentPage = this.paging.current;

  };

         public removeFilter () : void {
        this.filterShow = false;
        this.filterSearch = '';
    };

       public toggleLimitOptions () : any {
             this.limitOptions = this.limitOptions ? undefined : [5, 10, 15];
        };

    
    }

    angular.module(appConfig.appName).controller('HomeController', HomeController);
}
