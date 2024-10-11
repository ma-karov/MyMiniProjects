@extends('layouts.app')

@section('content')




<div class="content-wrapper">

    <!-- Content Header (Page header) -->
    <section class="content-header">

        <div class="col-sm-6">
            <h1>
                Schedule :
            </h1>
            <h2>{{$getRecordAll->first()->schedule_title}}</h2>

            <h3>Group : {{$getRecord->first()->group}}</h3>

            <h3>Saturday</h3>
        </div>


    </section>



    <!-- Main content -->
    <section class="content">
        <div class="row">

            <!-- /.col -->
            <div class="col-md-12">

                <div class="box">
                    @include('_message')

                    <div class="box-header">

                        @include('student.timeTable.tab')
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">

                        <div class="table-responsive">
                            <table class="table table-striped responsive table-bordered" id="scheduleTable">
                                <thead>
                                    <tr>
                                        <!-- <th>#</th> -->
                                        <!-- <th>Schedule Title</th> -->
                                        <!-- <th>Teacher</th> -->
                                        <th>Course Title</th>
                                        <th>Start Time</th>
                                        <th>End Time</th>
                                        <!-- <th>Group</th> -->
                                        <!-- <th>Room</th> -->
                                        <!-- <th>day</th> -->

                                    </tr>
                                </thead>
                                <tbody>
                                    @foreach($getRecord as $value)
                                    <tr>
                                        <!-- <td>{{$value->id}}</td> -->
                                        <!-- <td>{{$value->schedule_title}}</td> -->
                                        <!-- <td>{{$value->teacher_name}}</td> -->
                                        <td style="align-content: center;">{{$value->course_title}} <br>( {{$value->teacher_name}} )<br>room : {{$value->room}} </td>
                                        <td>{{$value->startTime}}</td>
                                        <td>{{$value->endTime}}</td>
                                        <!-- <td>{{$value->group}}</td> -->
                                        <!-- <td>{{$value->room}}</td> -->
                                        <!-- <td>{{$value->day}}</td> -->

                                    </tr>
                                    @endforeach
                                </tbody>

                            </table>
                        </div>

                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

    </section>
    <!-- /.content -->
</div>

@endsection


@section('script')


@endsection
