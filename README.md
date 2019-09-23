# Plugin.XamarinForms.Behaviors

Cross platform library containing a bunch of XAML behaviors for Xamarin Forms.

## Supported Platforms

| Name | Tested |
| - | - |
| Andriod | Yes |
| iOS | Yes |

## Setup

Install this package into your PCL/.NetStandard project. It does not require additional configuratios.

## Using the package

First, you just need to add the reference in your XAML file:

```XML
xmlns:behav="clr-namespace:Plugin.XamarinForms.Behaviors;assembly=Plugin.XamarinForms.Behaviors"
```

And then you can use it on this way:

```XML
<Entry Placeholder="Entry disable demo" IsEnabled="{Binding YourBindingProperty}">
	<Entry.Behaviors>
	    <behav:VisualElementEnableBehavior EnableStyle="{x:StaticResource enableStyle}"
	                                       DisableStyle="{x:StaticResource disableStyle}" />
    </Entry.Behaviors>
</Entry>

<Button Text="SOME ACTION" IsEnabled="{Binding YourBindingProperty">
    <Button.Behaviors>
        <behav:VisualElementEnableBehavior EnableStyle="{x:StaticResource btnEnableStyle}"
                                           DisableStyle="{x:StaticResource disableStyle}" />
    </Button.Behaviors>
</Button>

<Picker>
    <Picker.Items>
        <x:String>Select movie</x:String>
        <x:String>Toy Story</x:String>
        <x:String>A Bug's Life</x:String>
        <x:String>Monsters Inc.</x:String>
        <x:String>Finding Nemo</x:String>
        <x:String>The Incredibles</x:String>
        <x:String>Cars</x:String>
        <x:String>Ratatoullie</x:String>
        <x:String>WALL-E</x:String>
        <x:String>Up</x:String>
        <x:String>Brave</x:String>
        <x:String>Inside Out</x:String>
        <x:String>The Good Dinosaur</x:String>
        <x:String>Coco</x:String>
    </Picker.Items>
    <Picker.SelectedIndex>0</Picker.SelectedIndex>
    <Picker.Behaviors>
        <behav:PickerSelectedItemBehavior ValidItemStyle="{x:StaticResource enableStyle}"
                                          InvalidItemStyle="{x:StaticResource invalidValueStyle}" />
    </Picker.Behaviors>
</Picker>

<Entry Placeholder="Full name" Keyboard="Text" ReturnType="Next">
    <Entry.Behaviors>
        <behav:EntryFocusNextBehavior NextEntry="{Binding Source={x:Reference txtEmail}}" />
    </Entry.Behaviors>
</Entry>

<Entry Placeholder="Email" Keyboard="Email" ReturnType="Next" x:Name="txtEmail">
    <Entry.Behaviors>
        <behav:EntryFocusNextBehavior NextEntry="{Binding txtAge}" />
        <behav:EntryValidatorBehavior Pattern="^(\w+((\.|\-)\w+)*)\@(\w+((\.|\-)\w+)*(\.(\w){2,3}))$"
                                      ValidValueStyle="{x:StaticResource enableStyle}"
                                      NotValidValueStyle="{x:StaticResource invalidValueStyle}" />
    </Entry.Behaviors>
</Entry>

<Entry Placeholder="Age between 18 and 85" x:Name="txtAge">
    <Entry.Behaviors>
        <behav:EntryMinMaxBehavior MinValue="18" MaxValue="85"
                                   ValidValueStyle="{x:StaticResource enableStyle}"
                                   NotValidValueStyle="{x:StaticResource invalidValueStyle}" />
    </Entry.Behaviors>
</Entry>

<Entry Placeholder="USA phone" Keyboard="Telephone">
    <Entry.Behaviors>
        <behav:EntryMaskedBehavior Mask="(XXX) XXX-XXXX" />
    </Entry.Behaviors>
</Entry>
```

__Note:__

I tried `EntryFocusNextBehavior` inside a `TableView` and it didn't work.

## All behaviors

Here is the list off all behaviors implemented in this plugin:

 * VisualElementEnableBehavior
 * EntryFocusNextBehavior 
 * EntryMaskedBehavior
 * EntryMinMaxBehavior
 * EntryValidatorBehavior
 * PickerSelectedItemBehavior

You can dig into `Demo` project and see all of them in action.

### Contributions

This project stills under develop. If you want to add some behavior just feel free to do it.