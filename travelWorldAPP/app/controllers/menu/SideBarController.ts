/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class SideBarController {

        static $inject = [];

        public currentNavItem: string;

        constructor() {        
                this.setPage();
        }

        public setPage() :void {
            
            this.currentNavItem = 'page1';
            console.log("executou" + this.currentNavItem);
        }
       
    }

    angular.module(appConfig.appName).controller('SideBarController', SideBarController);
}