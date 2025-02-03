<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\ResourceCollection;

class AddBookAPI_Collection extends ResourceCollection
{
    public $collects = "App\Models\Book";

    /**
     * Transform the resource collection into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return array
        (
            'id' => $this->id,
            'appellation' => $this->appellation,
            'year' => $this->year,
            'genres' => $this->genres,
            'authors' => $this->authors
        );
    }
}
