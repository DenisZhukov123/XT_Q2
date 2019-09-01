function getSelectedIndexes(oListbox)
{
  var arrIndexes = new Array;
  for (var i=0; i < oListbox.options.length; i++)
  {
    if(oListbox.options[i].selected)
      arrIndexes.push(i);
  }
  return arrIndexes;
};
function delSelectedIndexes(oListbox, arrIn)
{
  var arrIndexes = arrIn;
  for(var i=arrIn.length-1;i>=0;i--)
    oListbox.options[arrIn[i]]=null
};

function moveSelOption(idselectfrom, idselectto)
{
  var objSelFrom = document.getElementById(idselectfrom); 
  var objSelTo = document.getElementById(idselectto); 
  var arrIndexes = getSelectedIndexes(objSelFrom);
  if(arrIndexes.length <= 0) 
    alert("Не выбран ни один элемент!"); 
  else
  {
    for (var i=0; i < arrIndexes.length; i++)
    {
      var text = objSelFrom.options[arrIndexes[i]].text;
      var value =  objSelFrom.options[arrIndexes[i]].value;
      var newOption = new Option(text,value);
      objSelTo.add(newOption);
    }
    delSelectedIndexes(objSelFrom, arrIndexes)
  }
}

function moveAllOption(idselectfrom, idselectto)
{
  var objSelFrom = document.getElementById(idselectfrom); 
  var objSelTo = document.getElementById(idselectto); 
  while(objSelFrom.length)
    objSelTo.add(objSelFrom.item(0));
}