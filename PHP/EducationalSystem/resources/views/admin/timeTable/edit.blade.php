@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Edit Schedule
        </h1>

    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <!-- left column -->
            <div class="col-md-12">
                <!-- general form elements -->
                <div class="box box-primary">

                    <!-- /.box-header -->
                    <!-- form start -->
                    <form method="post" action="">
                        {{ csrf_field() }}
                        <div class="box-body">

                            <div class="form-group">
                                <label>Schedule Title *</label>
                                <select class="form-control" name="schedule_title" required>
                                    <option value="{{ $getTimeTable->schedule_id}}" selected>{{ $getTimeTable->schedule_title}}</option>
                                    @foreach ($getSchedule as $group)
                                    <option value="{{ $group->id }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Teacher *</label>
                                <select class="form-control" name="teacher_id" required>
                                    <option value="{{ $getTimeTable->teacher_id}}" selected>{{ $getTimeTable->teacher_name}}</option>
                                    @foreach ($getTeacher as $group)
                                    <option value="{{ $group->id }}">
                                        {{ $group->name }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Course Title *</label>
                                <select class="form-control" name="course_title" required>
                                    <option value="{{ $getTimeTable->course_title}}" selected>{{ $getTimeTable->course_title}}</option>
                                    @foreach ($getCourse as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Start Time *</label>
                                <input type="time" class="form-control" name="startTime" value="{{ $getTimeTable->startTime}}" required placeholder="Enter start Time">
                            </div>

                            <div class="form-group">
                                <label>End Time *</label>
                                <input type="time" class="form-control" name="endTime" value="{{ $getTimeTable->endTime}}" required placeholder="End Time">
                            </div>

                            <div class="form-group">
                                <label>Group *</label>
                                <select class="form-control" name="group" required>
                                    <option value="{{ $getTimeTable->group}}" selected>{{ $getTimeTable->group}}</option>
                                    @foreach ($getGroup as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Room *</label>
                                <select class="form-control" name="room" required>
                                    <option value="{{ $getTimeTable->room}}" selected>{{ $getTimeTable->room}}</option>
                                    @foreach ($getRoom as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Day *</label>
                                <select class="form-control" name="day" required>
                                    <option value="{{ $getTimeTable->day}}"  selected>{{ $getTimeTable->day}}</option>
                                    <option value="Monday">Monday</option>
                                    <option value="Tuesday">Tuesday</option>
                                    <option value="Wednesday">Wednesday</option>
                                    <option value="Thursday">Thursday</option>
                                    <option value="Friday">Friday</option>
                                    <option value="Saturday">Saturday </option>
                                </select>
                            </div>

                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Update</button>

                            <a href="{{ url('admin/timeTable/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>
    <!-- /.content -->
</div>

@endsection
