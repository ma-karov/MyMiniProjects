<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Room;

class RoomController extends Controller
{
    public function list()
    {

        $data['getRoom'] = Room::getRoom();
        $data['header_title'] = 'Room List';
        return view('admin.room.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Room';
        return view('admin.room.add', $data);
    }

    public function insert(Request $request)
    {

        $room = new Room;
        $room->title = trim($request->room);


        $room->save();

        return redirect('admin/room/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getRoom'] = Room::getSingle($id);
        if (!empty($data['getRoom'])) {
            $data['header_title'] = 'Edit Room';
            return view('admin.room.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $room = Room::getSingle($id);
        $room->title = trim($request->room);

        $room->save();

        return redirect('admin/room/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $room = Room::getSingle($id);
        $room->is_deleted = 1;

        $room->save();

        return redirect('admin/room/list')->with('success', 'Admin successfully deleted');
    }
}
