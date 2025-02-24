<?php

namespace App\Providers;

use Illuminate\Support\ServiceProvider;

class AppServiceProvider extends ServiceProvider
{

    private function DependencyInjection_ShopBooksApiControllerRepository(): void
    {
        $this->app->bind(
            "App\Http\Controllers\Repositories\ShopBooksApiController\InterfaceShopBooksApiControllerRepository",
            "App\Http\Controllers\Repositories\ShopBooksApiController\ShopBooksApiControllerRepository"
        );
    }

    /**
     * Register any application services.
     */
    function register(): void
    {
        $this->DependencyInjection_ShopBooksApiControllerRepository();
    }

    /**
     * Bootstrap any application services.
     *
     * @return void
     */
    public function boot()
    {
        //
    }
}
