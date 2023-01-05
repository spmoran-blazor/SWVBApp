using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;
using WVBApp.Shared.Services.Data;
using WVBApp.Shared.Services.State;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;

namespace Client.Components
{
    public partial class EventManager: IDisposable
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
        bool _success;


        protected override async Task OnInitializedAsync()
        {
            _state = State;
            _data = Data;
            await GetScheduledEvents();
        }

        private async void RemoveEvent(EventWithCodeInfo evc)
        {
            bool? result = await DialogService.ShowMessageBox("Warning", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
            if (result is not null && result == true)
            {
                Event? evt = _events.Where(a => a.Id == evc.Id).FirstOrDefault();
                var postData = await _data.DeleteEvent(evt);
                await GetScheduledEvents();
                _success = true;
                Snackbar.Configuration.PositionClass = "Top-Center";
                Snackbar.Add("Event Removed!", Severity.Success);
                StateHasChanged();
            }
        }

        private async Task GetScheduledEvents()
        {
            if (_data is not null)
            {
                var data = await _data.GetScheduledEvents();
                _fullEvents = data.ToList();

                foreach (var v in _fullEvents)
                {
                    HeaderType ht = new HeaderType();
                    ht.Count = _fullEvents.Where(a => a.EventDate == v.EventDate).Count();
                    ht.EventDate = v.EventDate;
                    _headerDates.Add(ht);
                    //var exists = headerDates.Find(x => (x.EventDate == v.EventDate)).FirstOrDefault();
                    //if (!_headerDates.Find(x => (x.EventDate == v.EventDate)).fi
                    //    {
                    //    CartProduct obj = lst.Find(x => (x.Name == "product name"));
                    //}
                    //    _headerDates.Add(ht);
                }

                for (int i = 0; i <= 30; i++)
                {
                    DateTime dateTime= DateTime.Now.AddDays(i);
                    var exists = _headerDates.Find(x => x.EventDate == dateTime);

                    if (exists is null)
                    {
                    HeaderType ht = new HeaderType();
                    ht.EventDate = DateTime.Now.AddDays(i);
                    ht.Count = 0;
                    _headerDates.Add(ht);
                    }



                }

                


                var groups = _headerDates.Distinct().ToList();

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

    public class HeaderType
    {
        public int Count { get; set; }
        public DateTime EventDate { get; set; }
    }
}