# Ćwiczenie: Refaktoryzacja komponentu NavMenu.razor w Blazor

## Cel: Zrefaktoryzować istniejący komponent `NavMenu.razor` w aplikacji Blazor poprzez stworzenie reużywalnego komponentu MenuItem, który uprości strukturę menu nawigacyjnego i zwiększy jego czytelność oraz elastyczność.

## Opis problemu:
Aktualny kod w NavMenu.razor zawiera powtarzające się elementy menu w następującej formie:

```html

<div class="nav-item px-3">
    <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
    </NavLink>
</div>
<div class="nav-item px-3">
    <NavLink class="nav-link" href="customers">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Customers
    </NavLink>
</div>
<div class="nav-item px-3">
    <NavLink class="nav-link" href="products">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Products
    </NavLink>
</div>
```

Powtarzalność kodu utrudnia jego utrzymanie i skalowanie. Należy zrefaktoryzować `NavMenu.razor`, aby używał nowego komponentu `MenuItem`.

