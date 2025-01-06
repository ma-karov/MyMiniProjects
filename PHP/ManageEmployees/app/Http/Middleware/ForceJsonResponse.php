<?php

namespace App\Http\Middleware;

use Closure;

/**
 * Class ForceJsonResponse
 * @package App\Http\Middleware
 * @author IgorKorytin <ivkorytin@yandex.ru>
 */
class ForceJsonResponse
{
    /**
     * @param $request
     * @param Closure $next
     * @return mixed
     */
    public function handle($request, Closure $next)
    {
        $request->headers->set('Accept', 'application/json');
        return $next($request);
    }
}
