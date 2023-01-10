using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;
using WVBApp.Shared.Services.Data;
using WVBApp.Shared.Services.State;

namespace Client.Components
{
    public partial class EventManager : IDisposable
    {
        [Inject] StateAccessService State { get; set; }
        [Inject] DataAccessService Data { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        private DataAccessService? _data;
        private List<Event> _events = new List<Event>();
        private List<EventWithCodeInfo> _fullEvents = new List<EventWithCodeInfo>();
        private StateAccessService? _state;
        private List<HeaderType> _headerDates = new List<HeaderType>();
        bool _open;
        protected EventCreate? dc;

        private async Task OpenDrawer(EventWithCodeInfo evc, DateTime? evtd)
        {
            if(evc is not null)
            {
                _state.EventWithCodeInfo = evc;
            }

            if(evtd is not null)
            {
                EventWithCodeInfo evcti = new EventWithCodeInfo();
                evcti.EventDate = evtd.GetValueOrDefault();
                _state.EventWithCodeInfo = evcti;
            }

            _open = !_open;
            
        }

        async Task CloseAddScreen()
        {
            await dc._mudSelect.Clear();
            _open = !_open;
            if(_state is not null)
            {
                _state.SetEventWithCodeInfo(null);
            }

            await GetScheduledEvents();
            await FashionEvents(_fullEvents);
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            State.OnStateChange += StateHasChanged;
            _state = State;
            _data = Data;
            await GetScheduledEvents();
            await FashionEvents(_fullEvents);
        }

        private async void RemoveEvent(EventWithCodeInfo evc)
        {
            bool? result = await DialogService.ShowMessageBox("Warning", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
            if (result is not null && result == true)
            {
                Event? evt = _events.Where(a => a.Id == evc.Id).FirstOrDefault();
                var postData = await _data.DeleteEvent(evt);
                await GetScheduledEvents();
                await FashionEvents(_fullEvents);
                Snackbar.Configuration.PositionClass = "Top-Center";
                Snackbar.Add("Event Removed!", Severity.Success);
                StateHasChanged();
            }
        }

        private async Task GetScheduledEvents()
        {
            if (_data is not null)
            {
                _headerDates.Clear();
                var data = await _data.GetScheduledEvents();
                _fullEvents = data.ToList();

                foreach (var v in _fullEvents)
                {
                    HeaderType hta = new HeaderType();
                    hta.Count = _fullEvents.Where(a => a.EventDate.Date == v.EventDate.Date).Count();
                    hta.EventDate = v.EventDate.Date;

                    DateTime dta = hta.EventDate.Date;
                    var exists1 = _headerDates.Find(x => x.EventDate.Date == dta.Date);

                    if (exists1 is null)
                    {
                        _headerDates.Add(hta);
                    }

                }
                    for (int i = 0; i <= 30; i++)
                    {
                        DateTime dtb = DateTime.Now.AddDays(i).Date;
                        var exists2 = _headerDates.Find(x => x.EventDate.Date == dtb);

                        if (exists2 is null)
                        {
                            HeaderType htb = new HeaderType();
                            htb.EventDate = DateTime.Now.Date.AddDays(i).Date;
                            htb.Count = 0;
                            _headerDates.Add(htb);
                        }
                    }

                    StateHasChanged();
            }
        }

        private async Task FashionEvents(List<WVBApp.Shared.DTOs.EventWithCodeInfo> eventWithCodeInfos)
        {
            _events.Clear();
            foreach (var item in eventWithCodeInfos)
            {
                Event evt = new Event();
                evt.Id = item.Id;
                evt.AreaOfPlayId = item.AreaOfPlayId;
                evt.IsPartial = item.IsPartial;
                evt.ParticipantLimit = item.ParticipantLimit;
                evt.PartialGameId = item.PartialGameId;
                evt.EventComment = item.EventComment ?? null;
                evt.EventDate = item.EventDate;
                evt.EventTime = item.EventTime;
                evt.EventSchedulingCodeId = item.EventSchedulingCodeId;
                evt.IsCancelled = item.IsCancelled;
                evt.UpdatedBy = item.UpdatedBy;
                evt.UpdatedDate = item.UpdatedDate;
                _events.Add(evt);
            }
        }

        void IDisposable.Dispose()
        {
            _data = null;
            _state = null;
        }

    }

   
}