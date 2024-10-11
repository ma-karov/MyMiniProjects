<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Group extends Model
{
    protected $fillable = ['title'];

    static public function getGroup()
    {
        $request = request(); // get the current request instance

        $query = self::select('groups.*')
            ->where('is_deleted', '=', 0);

        // Name filter
        if (!empty($request->get('name'))) {
            $name = $request->get('name');
            $query = $query->where('title', 'like', '%' . $name . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('created_at', '=', $createdAt);
        }

        $query = $query->orderBy('id', 'desc')
            ->paginate(20);

        return $query;
    }


    static public function  getGroupAll()
    {
        $query = self::select('groups.*')
            ->where('is_deleted', '=', 0)
            ->orderBy('title', 'asc')
            ->get();

        return $query;
    }

    static public function getSingle($id)
    {
        return self::find($id);
    }
}
