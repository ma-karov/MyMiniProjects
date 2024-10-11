<ul class="nav nav-tabs" role="tablist">
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/monday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/monday') }}" role="tab">Monday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/tuesday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/tuesday') }}" role="tab">Tuesday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/wednesday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/wednesday') }}" role="tab">Wednesday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/thursday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/thursday') }}" role="tab">Thursday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/friday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/friday') }}" role="tab">Friday</a>
    </li>
    <li class="nav-item">
        <a class="nav-link {{ 'teacher/timeTable/saturday' == request()->path() ? 'active' : ''}}" href="{{ url('teacher/timeTable/saturday') }}" role="tab">Saturday</a>
    </li>
</ul>
<!-- Tab panes -->
<div class="tab-content">
    <div class="tab-pane {{ 'teacher/timeTable/monday' == request()->path() ? 'active' : ''}}" id="monday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'teacher/timeTable/tuesday' == request()->path() ? 'active' : ''}}" id="tuesday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'teacher/timeTable/wednesday' == request()->path() ? 'active' : ''}}" id="wednesday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'teacher/timeTable/thursday' == request()->path() ? 'active' : ''}}" id="thursday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'teacher/timeTable/friday' == request()->path() ? 'active' : ''}}" id="friday" role="tabpanel">
        <p></p><br>
    </div>
    <div class="tab-pane {{ 'teacher/timeTable/saturday' == request()->path() ? 'active' : ''}}" id="saturday" role="tabpanel">
        <p></p><br>
    </div>
</div>
