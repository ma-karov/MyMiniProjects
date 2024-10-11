<?php

namespace App\Providers;

use Illuminate\Support\Facades\Route;
use Illuminate\Foundation\Support\Providers\RouteServiceProvider as ServiceProvider;

class RouteServiceProvider extends ServiceProvider
{
    protected $namespace = 'App\Http\Controllers';

    /**
     * Define your route model bindings, pattern filters, etc.
     *
     * @return void
     */
    public function boot()
    {
        //

        parent::boot();
    }

    public function map(): void
    {
        $this->mapApiRoutes();

        $this->mapWebRoutes();

        $this->MapApiSecretSolidityRoutes();

        $this->MapAuthenticateUsersRoutes();
        //
    }

    protected function mapWebRoutes(): void
    {
        Route::middleware('web')
             ->namespace($this->namespace)
             ->group(base_path('routes/web.php'));
    }

    protected function mapApiRoutes(): void
    {
        Route::prefix('api')
             ->middleware('api')
             ->namespace($this->namespace)
             ->group(base_path('routes/api.php'));
    }

    protected function MapApiSecretSolidityRoutes(): void
    {
        Route::middleware('API_SECRET_SOLIDITY')
             ->namespace($this->namespace)
             ->group(base_path('routes/ApiSecretSolidity.php'));
    }

    protected function MapAuthenticateUsersRoutes(): void
    {
        Route::middleware("web")->namespace($this->namespace)->group(base_path("routes/AuthenticateUsers.php"));
    }
}
