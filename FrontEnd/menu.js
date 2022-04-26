const menuSize = "200px";

let open = true;

document.getElementsByClassName("menu")[0].addEventListener("click", (e) => {
  open = !open;
  toggleMenu();
});

document.querySelector("#btnClose").addEventListener("click", (e) => {
  open = false;
  toggleMenu();
});

function toggleMenu() {
  if (open) {
    document.getElementsByClassName("item1")[0].style.marginLeft = 0;
    document.getElementsByClassName("item2")[0].style.width = "calc(100% - 200px)";
    return;
  } else {
    document.getElementsByClassName("item1")[0].style.marginLeft = `-${menuSize}`;
    document.getElementsByClassName("item2")[0].style.width = "100%";
  }
}