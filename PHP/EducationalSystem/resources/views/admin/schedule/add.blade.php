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
                                <input type="text" class="form-control" name="title" required placeholder="Enter Schedule Title">
                            </div>

                            <div class="form-group">
                                <label>Start Date *</label>
                                <input type="date" class="form-control" name="startDate" required placeholder="Enter start Date">
                            </div>
                            <div class="form-group">
                                <label>End Date *</label>
                                <input type="date" class="form-control" name="endDate" required placeholder="End Date">
                            </div>

                            <div class="form-group">
                                <label>Group *</label>
                                <select class="form-control" name="group_id" required>
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getGroupAll as $group)
                                    <option value="{{ $group->id }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>

                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Save</button>
                            <a href="{{ url('admin/schedule/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>

</div>

@endsection
