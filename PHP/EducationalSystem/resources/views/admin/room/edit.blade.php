@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Edit Room
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
                                <label>Room *</label>
                                <input type="text" class="form-control" name="room" value="{{ $getRoom->title}}" required placeholder="Enter room title">
                            </div>

                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Update</button>

                            <a href="{{ url('admin/room/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>
    <!-- /.content -->
</div>

@endsection
