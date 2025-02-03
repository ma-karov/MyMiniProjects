<?php

namespace App\Http\Controllers;

class ShopBooksApiController extends Controller
{
    /** @var \App\Http\Controllers\Repositories\ShopBooksApiController\InterfaceShopBooksApiControllerRepository $interfaceRepository
    */
    private $interfaceRepository;

    function __construct(\App\Http\Controllers\Repositories\ShopBooksApiController\InterfaceShopBooksApiControllerRepository $interfaceRepository)
    {
        $this->interfaceRepository = $interfaceRepository;
    }

    function getPopulateAuthors(\App\Http\Requests\ShopBooksApiController\GetPopulateAuthors_FormRequest $httpFormRequest): array
    {
        return $this->interfaceRepository->getPopulateAuthors($httpFormRequest->validated());
    }

    function getPopulateBooks(\App\Http\Requests\ShopBooksApiController\GetPopulateBooks_FormRequest $httpFormRequest): array
    {
        return $this->interfaceRepository->getPopulateBooks($httpFormRequest->validated());
    }

    function addBook(\App\Http\Requests\ShopBooksApiController\AddBook_FormRequest $httpFormRequest): array
    {
        return $this->interfaceRepository->addBook($httpFormRequest->validated());
    }
}
