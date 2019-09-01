
function start()
{
  if (window.opener) 
  { 
    window.opener.close();
  }
  document.getElementById('startButton').disabled = true;
    if(document.getElementById('pauseButton').disabled)
      document.getElementById('pauseButton').disabled=false;
  window.intervalID = setInterval(timer, 1000);
}

function timer()
{
  var second = document.getElementById('second').innerHTML;
  if( second > 0 ) 
    second--;
  else
  {
    window.clearInterval(window.intervalID);
    nextpage();
  }
  document.getElementById('second').innerHTML = second;
}

function pause()
{
  document.getElementById('pauseButton').disabled = true;
  document.getElementById('startButton').disabled = false;
  window.clearInterval(window.intervalID);
}

function prevpage()
{
  var fileName = fileName = location.href.split("/").slice(-1);
  if(fileName=="2.html")
    window.location.href = "index.html";
  if(fileName=="3.html")
    window.location.href = "2.html";
  if(fileName=="4.html")
    window.location.href = "3.html";
  if(fileName=="5.html")
    window.location.href = "4.html";
  if(fileName=="6.html")
    window.location.href = "5.html";
  if(fileName=="7.html")
    window.location.href = "6.html";
  if(fileName=="8.html")
    window.location.href = "7.html";
  if(fileName=="9.html")
    window.location.href = "8.html";
}

function nextpage()
{
  var fileName = location.href.split("/").slice(-1);
  if(fileName=="index.html")
    window.location.href = "2.html";
  if(fileName=="2.html")
    window.location.href = "3.html";
  if(fileName=="3.html")
    window.location.href = "4.html";
  if(fileName=="4.html")
    window.location.href = "5.html";
  if(fileName=="5.html")
    window.location.href = "6.html";
  if(fileName=="6.html")
    window.location.href = "7.html";
  if(fileName=="7.html")
    window.location.href = "8.html";
  if(fileName=="8.html")
    window.open("9.html",'_parent');
  if(fileName=="9.html")
  {
    result = confirm("Нажмите 'Да' чтобы выполнить просмотр страниц сначала или 'Нет' чтобы закрыть окно");
    if(result)
     window.location.href = "index.html";
    else
    {
      var win = window.open("about:blank", "_self");
      win.close();
    }
  }
}