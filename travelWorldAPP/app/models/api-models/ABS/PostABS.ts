/// <reference path="../../../configs/_all.ts" />
module Travel_World {
    export class PostABS {
        public id: number;
        public title: string;
        public text: string;
        public date: Date;
        public picture: string;
        public video: string;
        public icon: string;

        public categoryId: number;
        public category: Category;

        public cityId: number;
        public city: City;

        public userId: number;
        public user: User;


        constructor() {

        }
    }
} 
