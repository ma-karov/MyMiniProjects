<?php

namespace App\Http\Controllers\Repositories\ShopBooksApiController;

interface InterfaceShopBooksApiControllerRepository
{
    function getPopulateAuthors(array $arrayValidatedParameters): array;
    function getPopulateBooks(array $arrayValidatedParameters): array;
    function addBook(array $arrayValidatedParameters): array;
}
