<?php

namespace App\Http\Controllers\Swagger;

/**
 * @OA\Info(
 *     title="ShopBooks Doc API",
 *     version="0.0.1"
 * ),
 * @OA\PathItem(
 *     path="/api/"
 * )
 *
 * @OA\Get(
 *     path="/api/GetPopulateAuthors",
 *     summary="Получение популярных авторов за период",
 *     tags={"ShopBooksApi"},
 *
 *     @OA\RequestBody(
 *         @OA\JsonContent(
 *             allOf={
 *                 @OA\Schema(
 *                     @OA\Property(property="date_from", type="integer", example="1600"),
 *                     @OA\Property(property="date_to", type="integer", example="1600"),
 *                     @OA\Property(property="genre_appellation", type="string", nullable=true, example="Жанр"),
 *                     @OA\Property(property="limit", type="integer", nullable=true, example="4")
 *                 )
 *             }
 *         )
 *     ),
 *
 *     @OA\Response(
 *         response=200,
 *         description="OK",
 *         @OA\JsonContent(
 *             @OA\Property(property="name", type="string", example="Автор"),
 *             @OA\Property(property="birth_day", type="string", example="2100-0-0"),
 *             @OA\Property(property="count", type="integer", example="0"),
 *         )
 *     ),
 * ),
 *
 * @OA\Get(
 *     path="/api/GetPopulateBooks",
 *     summary="Получение популярных книг за период",
 *     tags={"ShopBooksApi"},
 *
 *     @OA\RequestBody(
 *         @OA\JsonContent(
 *             allOf={
 *                 @OA\Schema(
 *                     @OA\Property(property="date_from", type="integer", example="1600"),
 *                     @OA\Property(property="date_to", type="integer", example="1600"),
 *                     @OA\Property(property="genre_appellation", type="string", nullable=true, example="Жанр"),
 *                     @OA\Property(property="limit", type="integer", nullable=true, example="4")
 *                 )
 *             }
 *         )
 *     ),
 *
 *     @OA\Response(
 *         response=200,
 *         description="OK",
 *         @OA\JsonContent(
 *             @OA\Property(property="appellation", type="string", example="Автор"),
 *             @OA\Property(property="year", type="integer", example="2100"),
 *             @OA\Property(property="genres", type="array", example="[1,2]", @OA\Items(type="integer")),
 *             @OA\Property(property="authors", type="array", example="[1,2]", @OA\Items(type="integer")),
 *             @OA\Property(property="birth_day", type="string", example="2100-0-0"),
 *             @OA\Property(property="count", type="integer", example="0"),
 *         )
 *     ),
 * ),
 *
 * @OA\Post(
 *     path="/api/AddBook",
 *     summary="Добавление книги",
 *     tags={"ShopBooksApi"},
 *
 *     @OA\RequestBody(
 *         @OA\JsonContent(
 *             allOf={
 *                 @OA\Schema(
 *                     @OA\Property(property="appellation", type="string", example="Автор"),
 *                     @OA\Property(property="year", type="integer", example="2100"),
 *                     @OA\Property(property="genres", type="array", example="[1,2]", @OA\Items(type="integer")),
 *                     @OA\Property(property="authors", type="array", example="[1,2]", @OA\Items(type="integer"))
 *                 )
 *             }
 *         )
 *     ),
 *
 *     @OA\Response(
 *         response=200,
 *         description="OK",
 *         @OA\JsonContent(
 *             @OA\Property(property="id", type="integer", example="1"),
 *             @OA\Property(property="appellation", type="string", example="Автор"),
 *             @OA\Property(property="year", type="integer", example="2100"),
 *             @OA\Property(property="genres", type="array", example="[1,2]", @OA\Items(type="integer")),
 *             @OA\Property(property="authors", type="array", example="[1,2]", @OA\Items(type="integer"))
 *         )
 *     ),
 * ),
 */
class ShopBooksApiController {}

