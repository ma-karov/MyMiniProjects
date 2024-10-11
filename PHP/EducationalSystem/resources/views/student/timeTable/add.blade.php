@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Add New Schedule
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
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getSchedule as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Teacher *</label>
                                <select class="form-control" name="teacher_name" required>
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getTeacher as $group)
                                    <option value="{{ $group->name }}">
                                        {{ $group->name }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>
                            <div class="form-group">
                                <label>Course *</label>
                                <select class="form-control" name="course_title" required>
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getCourse as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Start Time *</label>
                                <input type="text" class="form-control" name="startTime" required placeholder="Enter start Time">
                            </div>
                            <div class="form-group">
                                <label>End Time *</label>
                                <input type="text" class="form-control" name="endTime" required placeholder="End Time">
                            </div>

                            <div class="form-group">
                                <label>Group *</label>
                                <select class="form-control" name="group" required>
                                    <option value="" disabled selected>Choose...</option>
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
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getRoom as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Save</button>
                            <a href="{{ url('admin/timeTable/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>

</div>

@endsection
