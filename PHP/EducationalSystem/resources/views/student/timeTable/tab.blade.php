<ul class="nav nav-tabs" role="tablist">
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/monday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/monday') }}" role="tab">Monday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/tuesday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/tuesday') }}" role="tab">Tuesday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/wednesday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/wednesday') }}" role="tab">Wednesday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/thursday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/thursday') }}" role="tab">Thursday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/friday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/friday') }}" role="tab">Friday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'student/timeTable/saturday' == request()->path() ? 'active' : ''}}" href="{{ url('student/timeTable/saturday') }}" role="tab">Saturday</a>
    </li>
</ul>
<!-- Tab panes -->
<div class="tab-content">
    <div class="tab-pane {{ 'student/timeTable/monday' == request()->path() ? 'active' : ''}}" id="monday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'student/timeTable/tuesday' == request()->path() ? 'active' : ''}}" id="tuesday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'student/timeTable/wednesday' == request()->path() ? 'active' : ''}}" id="wednesday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'student/timeTable/thursday' == request()->path() ? 'active' : ''}}" id="thursday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'student/timeTable/friday' == request()->path() ? 'active' : ''}}" id="friday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'student/timeTable/saturday' == request()->path() ? 'active' : ''}}" id="saturday" role="tabpanel">
        <p></p><br>
    </div>
</div>
