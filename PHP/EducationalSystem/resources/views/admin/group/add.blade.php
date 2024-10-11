@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Add New Group
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
                                <label>Group *</label>
                                <input type="text" class="form-control" name="group"  required placeholder="Enter group title">
                            </div>


                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Save</button>
                            <a href="{{ url('admin/group/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>

</div>

@endsection
