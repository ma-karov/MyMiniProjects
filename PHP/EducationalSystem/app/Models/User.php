<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Laravel\Sanctum\HasApiTokens;
use Symfony\Component\HttpFoundation\Request;

class User extends Authenticatable
{
    use HasApiTokens, HasFactory, Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */
    protected $fillable = [
        'name',
        'email',
        'password',
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'remember_token',
    ];

    /**
     * The attributes that should be cast.
     *
     * @var array<string, string>
     */
    protected $casts = [
        'email_verified_at' => 'datetime',
    ];

    static public function getAdmin()
    {
        $request = request(); // get the current request instance

        $return = self::select('users.*')
            ->where('is_deleted', '=', 0);

        if (!empty($request->get('name'))) {
            $name = $request->get('name');
            $return = $return->where('name', 'like', '%' . $name . '%');
        }

        if (!empty($request->get('email'))) {
            $email = $request->get('email');
            $return = $return->where('email', 'like', '%' . $email . '%');
        }

        if (!empty($request->get('group_name'))) {
            $group_name = $request->get('group_name');
            $return = $return->where('group_name', 'like', '%' . $group_name . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $return = $return->whereDate('created_at', '=', $createdAt);
        }

        $return = $return->orderBy('id', 'desc')
            ->paginate(20);

        return $return;
    }

    static public function getTeacher()
    {
        return self::select('users.*')
            ->where('usertype', '=', 2)
            ->where('is_deleted', '=', 0)
            ->orderBy('name', 'asc')
            ->get();
    }

    static public function  getAdminAll()
    {
        $query = self::select('schedules.*')
            ->where('is_deleted', '=', 0)
            ->orderBy('title', 'asc')
            ->get();

        return $query;
    }

    static function getSingle($id)
    {
        return self::find($id);

        // return self::select('users.*', 'groups.title as group_title')
        //     ->join('groups', 'groups.id', '=', 'users.group_id')
        //     ->where('users.id', $id)
        //     ->first();
    }
}
