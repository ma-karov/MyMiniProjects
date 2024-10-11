<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\DashboardController;

use App\Http\Controllers\AdminController;
use App\Http\Controllers\GroupController;
use App\Http\Controllers\CourseController;
use App\Http\Controllers\ScheduleController;
use App\Http\Controllers\RoomController;
use App\Http\Controllers\TimeTableController;
use App\Http\Controllers\TeacherTimeTableController;
use App\Http\Controllers\StudentTimeTableController;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

// Route::get('/', function () {
//     return view('welcome');
// });


Route::get('/', [AuthController::class, 'login']);
Route::post('login', [AuthController::class, 'Authlogin']);
Route::get('logout', [AuthController::class, 'logout']);



Route::group(['middleware' => 'admin'], function () {

    Route::get('admin/dashboard', [DashboardController::class, 'dashboard']);

    Route::get('admin/admin/list', [AdminController::class, 'list']);
    Route::get('admin/admin/add', [AdminController::class, 'add']);
    Route::post('admin/admin/add', [AdminController::class, 'insert']);
    Route::get('admin/admin/edit/{id}', [AdminController::class, 'edit']);
    Route::post('admin/admin/edit/{id}', [AdminController::class, 'update']);
    Route::get('admin/admin/delete/{id}', [AdminController::class, 'delete']);


    Route::get('admin/group/list', [GroupController::class, 'list']);
    Route::get('admin/group/add', [GroupController::class, 'add']);
    Route::post('admin/group/add', [GroupController::class, 'insert']);
    Route::get('admin/group/edit/{id}', [GroupController::class, 'edit']);
    Route::post('admin/group/edit/{id}', [GroupController::class, 'update']);
    Route::get('admin/group/delete/{id}', [GroupController::class, 'delete']);


    Route::get('admin/course/list', [CourseController::class, 'list']);
    Route::get('admin/course/add', [CourseController::class, 'add']);
    Route::post('admin/course/add', [CourseController::class, 'insert']);
    Route::get('admin/course/edit/{id}', [CourseController::class, 'edit']);
    Route::post('admin/course/edit/{id}', [CourseController::class, 'update']);
    Route::get('admin/course/delete/{id}', [CourseController::class, 'delete']);

    Route::get('admin/schedule/list', [ScheduleController::class, 'list']);
    Route::get('admin/schedule/add', [ScheduleController::class, 'add']);
    Route::post('admin/schedule/add', [ScheduleController::class, 'insert']);
    Route::get('admin/schedule/edit/{id}', [ScheduleController::class, 'edit']);
    Route::post('admin/schedule/edit/{id}', [ScheduleController::class, 'update']);
    Route::get('admin/schedule/delete/{id}', [ScheduleController::class, 'delete']);

    Route::get('admin/room/list', [RoomController::class, 'list']);
    Route::get('admin/room/add', [RoomController::class, 'add']);
    Route::post('admin/room/add', [RoomController::class, 'insert']);
    Route::get('admin/room/edit/{id}', [RoomController::class, 'edit']);
    Route::post('admin/room/edit/{id}', [RoomController::class, 'update']);
    Route::get('admin/room/delete/{id}', [RoomController::class, 'delete']);

    Route::get('admin/timeTable/list', [TimeTableController::class, 'list']);
    Route::get('admin/timeTable/add', [TimeTableController::class, 'add']);
    Route::post('admin/timeTable/add', [TimeTableController::class, 'insert']);
    Route::get('admin/timeTable/edit/{id}', [TimeTableController::class, 'edit']);
    Route::post('admin/timeTable/edit/{id}', [TimeTableController::class, 'update']);
    Route::get('admin/timeTable/delete/{id}', [TimeTableController::class, 'delete']);

});

Route::group(['middleware' => 'teacher'], function () {

    Route::get('teacher/dashboard', [DashboardController::class, 'dashboard']);
    Route::get('teacher/timeTable/list', [TeacherTimeTableController::class, 'list']);
    Route::get('teacher/timeTable/monday', [TeacherTimeTableController::class, 'monday']);
    Route::get('teacher/timeTable/tuesday', [TeacherTimeTableController::class, 'tuesday']);
    Route::get('teacher/timeTable/wednesday', [TeacherTimeTableController::class, 'wednesday']);
    Route::get('teacher/timeTable/thursday', [TeacherTimeTableController::class, 'thursday']);
    Route::get('teacher/timeTable/friday', [TeacherTimeTableController::class, 'friday']);
    Route::get('teacher/timeTable/saturday ', [TeacherTimeTableController::class, 'saturday']);

    // Route::get('teacher/dashboard', function () {
    //     return view('admin.dashboard');
    // });
});

Route::group(['middleware' => 'student'], function () {

    Route::get('student/dashboard', [DashboardController::class, 'dashboard']);
    Route::get('student/timeTable/list', [StudentTimeTableController::class, 'list']);
    Route::get('student/timeTable/monday', [StudentTimeTableController::class, 'monday']);
    Route::get('student/timeTable/tuesday', [StudentTimeTableController::class, 'tuesday']);
    Route::get('student/timeTable/wednesday', [StudentTimeTableController::class, 'wednesday']);
    Route::get('student/timeTable/thursday', [StudentTimeTableController::class, 'thursday']);
    Route::get('student/timeTable/friday', [StudentTimeTableController::class, 'friday']);
    Route::get('student/timeTable/saturday ', [StudentTimeTableController::class, 'saturday']);

    // Route::get('/tab1', function () {
    //     return view('student.timeTable.list');
    // });
});
