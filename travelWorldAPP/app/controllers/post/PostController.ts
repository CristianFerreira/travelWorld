/// <reference path="../../configs/_all.ts" />

module Travel_World {
    export class PostController {

        static $inject = ['PostService', 'CityService','CategoryService', '$routeParams', '$location', 'toastr', '$mdDialog', '$timeout'];

        private postService: PostService;
        private cityService: CityService;
        private categoryService: CategoryService;
        public $routeParams: IRouteParamsService;
        private $location: ILocationService;
        public toastr: Toastr;
        public mdDialog: any;
        public timeout: ITimeoutService;
        public cities: Array<City>;
        public categorys: Array<Category>;
        public post: Post;

        constructor(postService: PostService, 
                    cityService: CityService,
                    categoryService: CategoryService,
                    $routeParams: IRouteParamsService,
                    $location: ILocationService,
                    toastr: Toastr,
                    mdDialog: any,
                    timeout: ITimeoutService) {

            this.postService = postService;
            this.cityService = cityService;
            this.categoryService = categoryService;
            this.$routeParams = $routeParams;
            this.$location = $location;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.timeout = timeout;
            this.cities = new Array<City>();
            this.categorys = new Array<Category>();
            this.loadPost();
           
        }

        public loadPost(): void {
             this.loadCategory();
             this.loadCity();
             if (this.$routeParams.id){
                 this.postService.getById(this.$routeParams.id)
                 .then((data) => {
                     this.post = data;
                 })
                 .catch((response) => console.log("Não carregou a postagem, erro: " + response) );
             }          
        }

        public loadCategory() : void {
           this.categoryService.listAll()
                .then((data) => {                 
                    this.categorys = data;                               
                })
                .catch((response) => console.log("Não carregou as categorias, erro: " + response));
        }

        public loadCity(): void {
            this.cityService.listAll()
                .then((data) => {
                    this.cities = data;
                })
                .catch((response) => console.log("Não carregou as cidades, erro: " + response));
        }


          public savePost() :void {          
              if(!this.post.id){
                  this.postService.savePost(this.post)
                    .then((data) => {                 
                        this.toastr.success("Postagem criada com sucesso!");
                        this.$location.path("postagem");                          
                    })
                    .catch((response) => {
                        this.toastr.error('Postagem não pode ser criada!');
                    })   
              }else {
                  this.postService.editPost(this.post)
                    .then((data) => {                 
                        this.toastr.success("Postagem editada com sucesso!"); 
                        this.$location.path("postagem/" + this.post.id);                         
                    })
                    .catch((response) => {
                        this.toastr.error('Postagem não pode ser editada!');
                    })   
              }         
        }
    }
    angular.module(appConfig.appName).controller('PostController', PostController);
}