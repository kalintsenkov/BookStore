import React, { useEffect, useState } from 'react';

interface IPaginationProps {
  page: number;
  totalPages: number;
  radius?: number;
  onPageSelected: (page: number) => void;
}

interface ILink {
  text: string;
  page: number;
  enabled: boolean;
  active: boolean;
}

const Pagination = ({ page = 1, totalPages, radius = 3, onPageSelected }: IPaginationProps): JSX.Element => {
  const [links, setLinks] = useState<ILink[]>([]);

  useEffect(() => {
    loadPages();
  }, [page, totalPages, radius]);

  const selectedPageInternal = async (link: ILink) => {
    if (link.page === page || !link.enabled) {
      return;
    }

    page = link.page;

    await onPageSelected(link.page);
  };

  const loadPages = () => {
    const previous = 'Previous';
    const next = 'Next';
    const isPreviousPageLinkEnabled = page !== 1;
    const previousPage = page - 1;

    const linkList: ILink[] = [
      {
        page: previousPage,
        enabled: isPreviousPageLinkEnabled,
        text: previous,
        active: false
      }
    ];

    for (let i = 1; i <= totalPages; i++) {
      if (i >= page - radius && i <= page + radius) {
        linkList.push({
          page: i,
          active: page === i,
          enabled: true,
          text: i.toString()
        });
      }
    }

    const isNextPageLinkEnabled = page !== totalPages;
    const nextPage = page + 1;

    linkList.push({
      page: nextPage,
      enabled: isNextPageLinkEnabled,
      text: next,
      active: false
    });

    setLinks(linkList);
  };

  return (
    <>
      {totalPages && (
        <nav className='mt-4'>
          <ul className='pagination'>
            {links.map((link, index) => (
              <li
                key={index}
                onClick={() => selectedPageInternal(link)}
                style={{ cursor: 'pointer' }}
                className={`page-item ${!link.enabled ? 'disabled' : ''} ${
                  link.active ? 'active' : ''
                }`}
              >
                <span className='page-link'>{link.text}</span>
              </li>
            ))}
          </ul>
        </nav>
      )}
    </>
  );
};

export default Pagination;